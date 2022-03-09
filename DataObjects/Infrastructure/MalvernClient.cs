using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public BaseMalvernResponse Send(BaseMalvernRequest payload, Dictionary<string, List<string>> carrierServiceMap, int timeout)
        {
            var stringToSend = payload.Encode(carrierServiceMap);

            var response = SendRaw(stringToSend, timeout);

            var result = BaseMalvernEntity.Decode(response) as BaseMalvernResponse;

            return result;
        }

        public string SendRaw(string payload, int timeout)
        {
            var sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(_host, _port);
            return sender.SendReceive(payload, timeout);
        }
    }

    public static class SocketExt
    {
        public static string SendReceive(this Socket socket, string data, int timeout)
        {
            var watcher = new Stopwatch();
            socket.Send(Encoding.ASCII.GetBytes(data));
            watcher.Start();
            var timeoutSpan = TimeSpan.FromSeconds(timeout);
            while (socket.Available == 0)
            {
                if (watcher.Elapsed > timeoutSpan)
                    throw new MalvernCommunicationException(data, $"Malvern request failed to respond within {timeout} seconds");
                Thread.Sleep(10);
            }

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