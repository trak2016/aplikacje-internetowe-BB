using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuertionnaireCreator.Startup))]
namespace QuertionnaireCreator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
