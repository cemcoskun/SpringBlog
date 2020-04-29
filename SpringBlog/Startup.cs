using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpringBlog.Startup))]
namespace SpringBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
