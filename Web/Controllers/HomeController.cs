using System.Configuration;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var connectionString = ConfigurationManager.AppSettings["Garmin2StravaTableStorage"];
            return View(new Stuff(connectionString));
        } 
    }
}