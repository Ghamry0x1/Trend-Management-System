using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Trend.Startup))]
namespace Trend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
