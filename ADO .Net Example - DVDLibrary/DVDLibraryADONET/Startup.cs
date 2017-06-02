using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DVDLibraryADONET.Startup))]
namespace DVDLibraryADONET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
