using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilmHaus.Startup))]
namespace FilmHaus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
