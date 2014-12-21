namespace ControlT.Mvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;
    using EF;
    using Models;
    using Utils;

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
                    Value = caja.CajaID.ToString(CultureInfo.InvariantCulture),
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
            var fecDesde = fechaDesde.ToDate();
            var fecHasta = fechaHasta.ToDate();

            var movimientosModel = new List<MovimientoModel>();

            var movimientosAnteriores = uow.Movimientos.Where(x => x.Caja.CajaID == idCaja && x.Fecha < fecDesde);
            var saldoAnterior = movimientosAnteriores.Any() ? movimientosAnteriores.Sum(x => x.Importe) : 0M;

            AddLineaSaldoAnteriorSiCorresponde(saldoAnterior, fecDesde, movimientosModel);
          
            var movimientos = uow.Movimientos.Where(x => x.Caja.CajaID == idCaja && x.Fecha >= fecDesde && x.Fecha <= fecHasta);
            AddLineas(movimientos, saldoAnterior, movimientosModel);

            return this.PartialView(movimientosModel);
        }

        public ActionResult Create()
        {
            return this.View();
        }

        private static void AddLineaSaldoAnteriorSiCorresponde(decimal saldoAnterior, DateTime fecDesde, ICollection<MovimientoModel> movimientosModel)
        {
            if (saldoAnterior <= 0) return;
            var movimientoModel = new MovimientoModel(fecDesde.AddDays(-1), saldoAnterior);
            movimientosModel.Add(movimientoModel);
        }
        private static void AddLineas(IEnumerable<Movimiento> movimientos, decimal saldo, ICollection<MovimientoModel> movimientosModel)
        {
            foreach (var movimiento in movimientos)
            {
                saldo += movimiento.Importe;
                var movimientoModel = new MovimientoModel(movimiento, saldo);
                movimientosModel.Add(movimientoModel);
            }
        }
    }
}
