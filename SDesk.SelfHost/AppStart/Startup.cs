using System.Web.Http;
using Owin;
using SDesk.API;

namespace SDesk.SelfHost.AppStart
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);

            app.UseWebApi(config);
        }
    }
}