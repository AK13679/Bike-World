using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BikeWorld.Startup))]
namespace BikeWorld
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           ConfigureAuth(app);
        }
    }
}
