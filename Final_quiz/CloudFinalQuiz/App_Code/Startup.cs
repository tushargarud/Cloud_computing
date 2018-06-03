using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CloudFinalQuiz.Startup))]
namespace CloudFinalQuiz
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
