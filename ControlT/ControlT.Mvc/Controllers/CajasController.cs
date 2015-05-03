namespace ControlT.Mvc.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using EF;
    using Models;

    public class CajasController : Controller
    {
        public ActionResult Index()
        {
            var context = new ControlTContext();
            var cajas = context.Cajas.ToArray();
            return View(cajas);
        }

        public ActionResult Detail(int id)
        {
            var context = new ControlTContext();
            var caja = context.Cajas.Single(x => x.CajaID == id);
            var model = new CajaModel(caja);
            return View(model);
        }
    }
}
