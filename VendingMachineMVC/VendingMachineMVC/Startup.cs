using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VendingMachineMVC.Startup))]
namespace VendingMachineMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
