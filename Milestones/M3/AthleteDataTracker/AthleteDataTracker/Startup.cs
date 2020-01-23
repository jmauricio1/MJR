using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AthleteDataTracker.Startup))]
namespace AthleteDataTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
