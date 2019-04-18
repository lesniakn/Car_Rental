using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Car_Rental.Startup))]
namespace Car_Rental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
