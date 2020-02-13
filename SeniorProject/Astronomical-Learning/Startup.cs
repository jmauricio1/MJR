using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Astronomical_Learning.Startup))]
namespace Astronomical_Learning
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
