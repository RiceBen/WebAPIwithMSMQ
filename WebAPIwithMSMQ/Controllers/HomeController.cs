using System.Web.Mvc;
using WebAPIwithMSMQ.Services;

namespace WebAPIwithMSMQ.Controllers
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