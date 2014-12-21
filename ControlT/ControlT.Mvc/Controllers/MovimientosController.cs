namespace ControlT.Mvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
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
            var fecDesde = this.GetFecha(fechaDesde);
            var fecHasta = this.GetFecha(fechaHasta);
            var movimientosModel = new List<MovimientoModel>();

            var movimientosAnteriores = uow.Movimientos.Where(x => x.Caja.CajaID == idCaja && x.Fecha < fecDesde);
            var saldoAnterior = movimientosAnteriores.Any() ? movimientosAnteriores.Sum(x => x.Importe) : 0M;

            if (saldoAnterior > 0)
            {
                var movimientoModel = new MovimientoModel(fecDesde.AddDays(-1), saldoAnterior);
                movimientosModel.Add(movimientoModel);
            }

            var movimientos = uow.Movimientos.Where(x => x.Caja.CajaID == idCaja && x.Fecha >= fecDesde && x.Fecha <= fecHasta);

            var saldo = saldoAnterior;
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
