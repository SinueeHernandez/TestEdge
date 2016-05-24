using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_CSharpCodeAtRunTime.Models;
using Test_CSharpCodeAtRunTime.Utilities;

namespace Test_CSharpCodeAtRunTime.Controllers
{
    public class CodeAtRunTimeController : Controller
    {
        private static CompileExecute _compileExecute = new CompileExecute();
        public CodeAtRunTime Rule = new CodeAtRunTime();
        // GET: CodeAtRunTime
        [ValidateInput(false)]
        public ActionResult Index()
        {
            Rule.functionName = "SayHello";
            Rule.source = @"public string SayHello()
        {
            return ""Hello World"";
        }";
            return View(Rule);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Run(CodeAtRunTime Rule)
        {
            object[] listaParams = null;
            int i = 0;
            var parameters = Rule.parameters.Split(',').ToList();
            if (parameters.Count > 0)
            {
                listaParams = new object[parameters.Count];
                foreach (var item in parameters)
                {
                    listaParams[i] = item;
                    i++;
                }
            }
            var Respuesta = _compileExecute.RunSomeCode(Rule.source, Rule.functionName, listaParams.ToArray());
            if (Respuesta.StatusCode == StatusResponse.OK)
            {
                Rule.result = Respuesta.Response;
            }
            else
            {
                foreach (var item in Respuesta.Errores)
                {
                    Rule.result += item.ToString();
                }
            }
            return View(Rule);
        }
    }
}