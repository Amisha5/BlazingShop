using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlazingShopProject.Startup))]
namespace BlazingShopProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
