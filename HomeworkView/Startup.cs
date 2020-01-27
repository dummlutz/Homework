using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeworkView.Startup))]
namespace HomeworkView
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
