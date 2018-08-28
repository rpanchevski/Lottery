using System.Web.Http;

namespace Lottery.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            IocConfig.Initialize(GlobalConfiguration.Configuration);
        }
    }
}
