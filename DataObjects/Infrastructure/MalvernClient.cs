using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Pro4Soft.Malvern.DataObjects.Dtos;

namespace Pro4Soft.Malvern.DataObjects.Infrastructure
{
    public class MalvernClient
    {
        private readonly string _host;
        private readonly int _port;

        public MalvernClient(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public BaseMalvernResponse Send(BaseMalvernRequest payload)
        {
            var stringToSend = payload.Encode();

            var response = SendRaw(stringToSend);

            var result = BaseMalvernEntity.Decode(response) as BaseMalvernResponse;

            return result;
        }

        public string SendRaw(string payload)
        {
            var sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(_host, _port);
            return sender.SendReceive(payload);
        }
    }

    public static class SocketExt
    {
        public static string SendReceive(this Socket socket, string data)
        {
            socket.Send(Encoding.ASCII.GetBytes(data));
            while (socket.Available == 0)
                Thread.Sleep(10);

            using var mem = new MemoryStream();
            var buffer = new byte[1024];
            while (socket.Available > 0)
            {
                var reads = socket.Receive(buffer, buffer.Length, SocketFlags.None);
                mem.Write(buffer, 0, reads);
            }
            return Encoding.ASCII.GetString(mem.ToArray());
        }
    }
}