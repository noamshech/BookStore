using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookPlace.Startup))]
namespace BookPlace
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
