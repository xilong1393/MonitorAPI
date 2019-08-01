using MonitorAPI.Service;
using System.Web.Mvc;

namespace MonitorAPI.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
