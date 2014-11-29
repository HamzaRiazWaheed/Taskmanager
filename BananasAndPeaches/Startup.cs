using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BananasAndPeaches.Startup))]
namespace BananasAndPeaches
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
