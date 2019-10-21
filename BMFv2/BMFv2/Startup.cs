using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BMFv2.Startup))]
namespace BMFv2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
