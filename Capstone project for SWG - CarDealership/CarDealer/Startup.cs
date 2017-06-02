using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarDealer.Startup))]
namespace CarDealer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
