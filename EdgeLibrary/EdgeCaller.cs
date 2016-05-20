using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdgeJs;

namespace EdgeLibrary
{
    public class EdgeCaller
    {
        public string SampleEdgeFuncion(string mensaje)

        {
            var func = Edge.Func(@"
            return function (data, callback) {
                callback(null, 'Node.js welcomes ' + data);
            }
        ");
            return func(mensaje).ToString();
        }

        public static async void Start()
        {
            var func = Edge.Func(@"
        return function (data, cb) {
            cb(null, 'Node.js ' + process.version + ' welcomes ' + data);
        }
    ");

             var t = await func(".NET");
            
        }
    }
}
