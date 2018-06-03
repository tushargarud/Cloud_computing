using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSE6331_Project2_Azure.Startup))]
namespace CSE6331_Project2_Azure
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
