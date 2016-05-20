using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdgeLibrary;

namespace Testing_Edge.Services
{
    public class EdgeService
    {
        private static EdgeCaller  _edgeCaller = new EdgeCaller();
        public string HelloNode(string param)
        {
            try
            {
                var ret = _edgeCaller.SampleEdgeFuncion(param);
                return ret;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
