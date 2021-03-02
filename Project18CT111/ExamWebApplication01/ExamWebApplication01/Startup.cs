using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamWebApplication01.Startup))]
namespace ExamWebApplication01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
