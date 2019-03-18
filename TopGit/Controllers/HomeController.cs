using System.Threading.Tasks;
using System.Web.Mvc;
using TopGit.Service;

namespace TopGit.Controllers
{
    public class HomeController : Controller
    {
        //JQuery
        public ActionResult TopStars()
        {
            return View();
        }

        //MVC
        public  ActionResult TopFive()
        {
            return View();
        }

        public async Task<ActionResult>  GetTopFive(string language)
        {
            var topFive = new TopFive();
            var a = await topFive.GetTopFive(language);

            return Json(a, JsonRequestBehavior.AllowGet);
            
        }
    }
}