using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(The_Ride_You_Rent.Startup))]
namespace The_Ride_You_Rent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
