using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdgeJs;
//using EdgeLibrary;

namespace Testing_Edge.Services
{
    public class EdgeService
    {
        //private static EdgeCaller  _edgeCaller = new EdgeCaller();
        public async Task SampleEdgeFuncion(string mensaje)

        {
            try
            {
                var func = Edge.Func(@"
            return function (data, callback) {
                callback(null, 'Node.js welcomes ' + data);
            }
        ");

                //var ret = await func(mensaje);
                return await func(mensaje);
            }
            catch (AggregateException ae)
            {
                return Task.Factory.StartNew(() =>
               {
                  return ae.Message;
               });
            }

        }
        public  Task HelloNode(string param)
        {
            //try
            //{

                //var ret = _edgeCaller.SampleEdgeFuncion(param);
                //var ret = ;
                return  SampleEdgeFuncion(param);
            //}
            //catch(Exception ex)
            //{
            //    return ex.Message;
            //}
        }


    }
}
