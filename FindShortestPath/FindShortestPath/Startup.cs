using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FindShortestPath.Startup))]
namespace FindShortestPath
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
