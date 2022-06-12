using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(carrentalservice.Startup))]
namespace carrentalservice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
