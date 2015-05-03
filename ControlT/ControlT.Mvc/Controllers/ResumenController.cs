namespace ControlT.Mvc.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Services.Protocols;
    using EF;
    using Models;

    public class ResumenController : Controller
    {

        public ActionResult Index()
        {
            var uow = new ControlTContext();
            var movimientos = uow.Movimientos.ToArray();
            var model = new ResumenModel(movimientos);
            return View(model);
        }

    }
}
