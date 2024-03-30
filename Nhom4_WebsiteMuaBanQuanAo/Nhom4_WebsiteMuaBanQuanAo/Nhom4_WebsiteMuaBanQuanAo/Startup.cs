using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nhom4_WebsiteMuaBanQuanAo.Startup))]
namespace Nhom4_WebsiteMuaBanQuanAo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
