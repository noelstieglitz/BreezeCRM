using System.Data.Entity;
using System.Web;
using System.Web.Http;
using BreezeCRM.Migrations;
using BreezeCRM.Models;

namespace BreezeCRM
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CrmContext, Configuration>());
        }
    }
}
