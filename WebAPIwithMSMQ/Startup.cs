using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebAPIwithMSMQ.Startup))]

namespace WebAPIwithMSMQ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutofacConfig.Bootstrapper(app);
            ConfigureAuth(app);
        }
    }
}