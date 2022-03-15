using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(efb_admin.Startup))]
namespace efb_admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
