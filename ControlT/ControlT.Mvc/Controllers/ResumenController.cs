namespace ControlT.Mvc.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using EF;
    using Models;
    using Utils;

    public class ResumenController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Movimientos(string fechaDesde, string fechaHasta)
        {
            var uow = new ControlTContext();

            var fecDesde = fechaDesde.ToDate();
            var fecHasta = fechaHasta.ToDate();
            var movimientos = uow.Movimientos.Where(x => x.Fecha >= fecDesde && x.Fecha <= fecHasta).Include(x => x.Caja).ToArray();
            var model = new ResumenModel(movimientos);
            return this.PartialView(model);
        }
    }
}
