using Microsoft.CodeDom.Providers.DotNetCompilerPlatform;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Test_CSharpCodeAtRunTime.Utilities
{
    public  class CompileExecute
    {
        public CompilerResponse RunSomeCode(string source, string funtionName, object[] parameters)
        {
            CompilerResults results = null;
            try
            {
                source = @"
namespace Foo
{
    public class Bar
    { " + "\n" + source + @"}
}
            ";

                Dictionary<string, string> providerOptions = new Dictionary<string, string>
                {
                    {"CompilerVersion", "v3.5"}
                };
                CSharpCodeProvider provider = new CSharpCodeProvider();


                CompilerParameters compilerParams = new CompilerParameters
                {
                    GenerateInMemory = true,
                    GenerateExecutable = false
                };

                results = provider.CompileAssemblyFromSource(compilerParams, source);

                if (results.Errors.Count != 0)
                    throw new Exception("Mission failed!");
            }
            catch(Exception ex)
            {
                List<string> ListaErrores = new List<string>();
                foreach (CompilerError item in results.Errors)
                {
                    ListaErrores.Add(item.Line + " ln | Error: " + item.ErrorNumber + " | " + item.ErrorText);
                }
                return new CompilerResponse()
                {
                    StatusCode = StatusResponse.CompilationErrors,
                    Response = "Errors on compilation",
                    Errores = ListaErrores
                };
            }
            try
            { 
                object o = results.CompiledAssembly.CreateInstance("Foo.Bar");
                MethodInfo mi = o.GetType().GetMethod(funtionName);
                var ret = mi.Invoke(o, parameters);

                return new CompilerResponse()
                {
                    StatusCode = StatusResponse.OK,
                    Response = ret.ToString(),
                    Errores = new List<string>()
                };
            }
            catch(Exception ex)
            {
                List<string> ListaErrores = new List<string>();
                ListaErrores.Add(ex.Message);

                return new CompilerResponse()
                {
                    StatusCode = StatusResponse.ExecutingErrors,
                    Response = "We had some Errors on execution, please check your code.",
                    Errores = ListaErrores
                };
            }
            
        }
    }
}