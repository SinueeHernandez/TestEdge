using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Test_CSharpCodeAtRunTime.Startup))]
namespace Test_CSharpCodeAtRunTime
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
