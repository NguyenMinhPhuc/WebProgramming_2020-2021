using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelloWebsite_MVCTemplate.Startup))]
namespace HelloWebsite_MVCTemplate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
