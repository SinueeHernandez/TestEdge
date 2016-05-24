using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_CSharpCodeAtRunTime.Utilities
{
    public class CompilerResponse
    {
        public List<string> Errores { get; set; }
        public StatusResponse StatusCode { get; set; }
        public string Response { get; set; }
    }
    public enum StatusResponse
    {
        OK,
        CompilationErrors,
        ExecutingErrors
    }
}