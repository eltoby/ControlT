namespace ControlT.Mvc.Controllers
{
    using System.Web.Mvc;
    using EF;
    using Models;

    public class CajasController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Cajas()
        {
            var uow = new ControlTContext();
            var model = new CajasModel(uow.Cajas);
            return this.PartialView(model);            
        }

        public ActionResult Create()
        {
            return this.PartialView();
        }

        [HttpPost]
        public ActionResult Create(CajaModel caja)
        {
            var uow = new ControlTContext();

            var nueva = new Caja
            {
                Nombre = caja.Nombre
            };

            uow.Cajas.Add(nueva);
            uow.SaveChanges();
            var result = new { success = true };
            return Json(result);
        }
    }
}