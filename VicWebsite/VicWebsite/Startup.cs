using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VicWebsite.Startup))]
namespace VicWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
