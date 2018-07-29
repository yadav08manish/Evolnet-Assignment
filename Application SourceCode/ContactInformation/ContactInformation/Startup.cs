using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContactInformation.Startup))]
namespace ContactInformation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
