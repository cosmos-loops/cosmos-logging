using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using Cosmos.Logging;
using Cosmos.Logging.Events;

namespace Cosmos.Loggings.SampleSink_AspNetMvc {
    public class Global : HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            this.RegisterCosmosLogging(s => s.ToGlobal(c => c.UseMinimumLevel(LogEventLevel.Verbose)).AddSampleLog());
        }

        protected void Application_BeginRequest(object sender, EventArgs e) {
            this.RegisterOnBegin();
        }

        protected void Application_EndRequest(object sender, EventArgs e) {
            this.RegisterOnEnd();
        }

        protected void Application_Error(object sender, EventArgs e) {
            this.RegisterOnError();
        }
    }
}