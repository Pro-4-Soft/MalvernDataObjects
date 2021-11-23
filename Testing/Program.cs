using System;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Console.Out.WriteLineAsync("Hello World!");
        }
    }
}
