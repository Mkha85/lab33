using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bai3.Startup))]
namespace bai3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
