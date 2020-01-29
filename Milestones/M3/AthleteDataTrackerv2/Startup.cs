using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AthleteDataTrackerv2.Startup))]
namespace AthleteDataTrackerv2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
