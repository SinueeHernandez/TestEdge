using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdgeJs;

namespace ConsoleEdge
{
    class Program
    {
        public static async Task Start()
        {
            var func = Edge.Func(@"
            return function (data, callback) {
                callback(null, 'Node.js welcomes ' + data);
            }
        ");

            Console.WriteLine(await func(".NET"));
        }

        static void Main(string[] args)
        {
            Start().Wait();
        }
    }
}
