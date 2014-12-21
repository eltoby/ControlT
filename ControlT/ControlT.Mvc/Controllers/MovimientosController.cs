namespace ControlT.Mvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using EF;
    using Models;

    public class MovimientosController : Controller
    {
        public ActionResult Index()
        {
            var uow = new ControlTContext();

            var cajas = new List<SelectListItem>();
            var selected = true;

            foreach (var caja in uow.Cajas.ToArray())
            {
                var li = new SelectListItem
                {
                    Text = caja.Nombre,
                    Value = caja.CajaID.ToString(),
                    Selected = selected
                };
                cajas.Add(li);
                selected = false;
            }

            var model = new MovimientosModel(cajas);
            return View(model);
        }

        public ActionResult Movimientos(int idCaja, string fechaDesde, string fechaHasta)
        {
            var uow = new ControlTContext();

            var fecDesde = this.GetFecha(fechaDesde);
            var fecHasta = this.GetFecha(fechaHasta);
            var movimientos = uow.Movimientos.Where(x => x.Caja.CajaID == idCaja && x.Fecha >= fecDesde && x.Fecha <= fecHasta);
            var movimientosModel = new List<MovimientoModel>();

            var saldo = 0M;
            
            foreach (var movimiento in movimientos)
            {
                saldo += movimiento.Importe;
                var movimientoModel = new MovimientoModel(movimiento, saldo);
                movimientosModel.Add(movimientoModel);
            }

            return this.PartialView(movimientosModel);
        }

        public ActionResult Create()
        {
            return this.View();
        }

        private DateTime GetFecha(string fecha)
        {
            var partes = fecha.Split('-');
            return new DateTime(int.Parse(partes[2]), int.Parse(partes[1]), int.Parse(partes[0]));
        }
    }
}
