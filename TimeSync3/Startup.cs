using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimeSync3.Startup))]
namespace TimeSync3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
