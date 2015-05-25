using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(newBeta.Startup))]
namespace newBeta
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
