using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(trabalhocsharpfeevale.Startup))]
namespace trabalhocsharpfeevale
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
