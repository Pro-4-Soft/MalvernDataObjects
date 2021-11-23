using System;
using System.Threading.Tasks;
using Pro4Soft.Malvern.DataObjects.Dtos;
using Pro4Soft.Malvern.DataObjects.Infrastructure;

namespace Testing
{
    class Program
    {
        private static readonly string host = "malvern";
        private static readonly int port = 1022;

        static async Task Main(string[] args)
        {
            //Rating
            //var t = "0,\"002\"1,\"12345\"12,\"John Doe\"11,\"ABC Company\"13,\"123 Main St\"15,\"Malvern\"16,\"PA\"17,\"19355\"21,\"5\"19,\"UPS\"22,\"1DY\"99,\"\"";

            //Shipping
            //var t = "0,\"001\"1,\"12345\"11,\"ABC Company\"12,\"John Doe\"13,\"123 Main St\"15,\"Malvern\"16,\"PA\"17,\"19355\" 19,\"UPS\"21,\"10\"22,\"GND\"99,\"\"";

            //Rate shopping
            var t = "0,\"003\"1,\"12345\"12,\"John Doe\"11,\"ABC Company\"13,\"123 Main St\"15,\"Malvern\"16,\"PA\"17,\"19355\"21,\"5\"1033,\"UPS GND,FDX GND,USP PRT\"99,\"\"";
            
            var resp = new MalvernClient(host, port).Send(BaseMalvernEntity.Decode(t) as BaseMalvernRequest);

            await Console.Out.WriteLineAsync(resp.Encode());

            await Console.In.ReadLineAsync();
        }
    }
}
