using System;
using Cosmos.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.Loggings.SampleSink_AspNetCore.Controllers {
    public class HomeController : Controller {
        private readonly ILoggingServiceProvider _loggingProvider;

        public HomeController(ILoggingServiceProvider loggingProvider) {
            _loggingProvider = loggingProvider ?? throw new ArgumentNullException(nameof(loggingProvider));
        }

        // GET
        public IActionResult Index() {
            var log = _loggingProvider.GetLogger<HomeController>();
            log.LogInformation("Nice @ {$Date}");
            return Content("Nice");
        }
    }
}