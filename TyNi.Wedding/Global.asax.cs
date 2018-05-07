using System.Web.Http;
using TyNi.Wedding.App_Start;

namespace TyNi.Wedding
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AutoMapperConfig.Initialize();

        }
    }
}
