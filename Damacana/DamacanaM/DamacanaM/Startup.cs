using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DamacanaM.Startup))]
namespace DamacanaM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
