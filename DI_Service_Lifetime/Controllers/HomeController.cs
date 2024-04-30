using DI_Service_Lifetime.Models;
using DI_Service_Lifetime.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace DI_Service_Lifetime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISingletonGuidService _singleton1;
        private readonly ISingletonGuidService _singleton2;

        private readonly IScopedGuidService _scoped1;
        private readonly IScopedGuidService _scoped2;

        private readonly ITransientGuidService _transient1;
        private readonly ITransientGuidService _transient2;


        public HomeController(IScopedGuidService scoped1,
                              IScopedGuidService scoped2,
                              ISingletonGuidService singleton1,
                              ISingletonGuidService singleton2,
                              ITransientGuidService transient1,
                              ITransientGuidService transient2)
        {
            _singleton1 = singleton1;
            _singleton2 = singleton2;
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _transient1 = transient1;
            _transient2 = transient2;
        }

        public IActionResult Index()
        {
            StringBuilder msg = new StringBuilder();
            msg.Append($"Transient 1 : {_transient1.GetGuid()} \n");
            msg.Append($"Transient 1 : {_transient2.GetGuid()} \n");
            msg.Append($"Scoped 1 : {_scoped1.GetGuid()} \n");
            msg.Append($"Scoped 2 : {_scoped2.GetGuid()} \n");
            msg.Append($"Singleton 1 : {_singleton1.GetGuid()} \n");
            msg.Append($"Singleton 2 : {_singleton2.GetGuid()} \n");
            return View(msg.ToString());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
