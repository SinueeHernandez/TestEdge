using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testing_Jurassic.BussinessLogic
{
    public class JurassicService
    {
        public string UseJurassic(List<string> Parameters )
        {
            int a;
            int b;

            int.TryParse(Parameters[0], out a);
            int.TryParse(Parameters[1], out b);

            var engine = new Jurassic.ScriptEngine();
            engine.Evaluate("function test(a, b) { return a + b }");
            var ret = engine.CallGlobalFunction<int>("test", a, b);


            return ret.ToString();
        }
    }
}