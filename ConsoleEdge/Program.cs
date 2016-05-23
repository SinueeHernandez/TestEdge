using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdgeJs;
using EdgeLibrary;

namespace ConsoleEdge
{
    class Program
    {
        private static EdgeCaller _edgeCaller = new EdgeCaller();
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
            try
            {
                var ret = _edgeCaller.SampleEdgeFuncion("Fuck yuo!!");
                Console.WriteLine(ret);
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message);
            }
        }
    }
}
