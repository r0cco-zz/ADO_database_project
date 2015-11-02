using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADO_database_project.UI.Startup))]
namespace ADO_database_project.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
