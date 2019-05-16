using System.Web.Mvc;

namespace AngelinaPrj.Controllers
{
    public class PainelController : Controller
    {
        //GET: Painel
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Mensagens()
        {
            return View();
        }
    }
}