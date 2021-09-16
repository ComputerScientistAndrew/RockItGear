using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RockItGear.Startup))]
namespace RockItGear
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
