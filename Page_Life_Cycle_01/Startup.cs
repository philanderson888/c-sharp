using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Page_Life_Cycle_01.Startup))]
namespace Page_Life_Cycle_01
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
