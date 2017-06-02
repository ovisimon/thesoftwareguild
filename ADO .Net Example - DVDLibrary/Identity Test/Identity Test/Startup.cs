using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Identity_Test.Startup))]
namespace Identity_Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
