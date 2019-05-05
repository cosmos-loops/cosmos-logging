using System.Web.Mvc;
using Cosmos.Logging;

namespace Cosmos.Loggings.SampleSink_AspNetMvc.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            var logger = LOGGER.GetLogger<HomeController>();
            logger.LogFatal("Error:)");

            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}