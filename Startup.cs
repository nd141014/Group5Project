using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Group5Project.Startup))]
namespace Group5Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
