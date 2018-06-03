using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Azure_Project2.Startup))]
namespace Azure_Project2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
