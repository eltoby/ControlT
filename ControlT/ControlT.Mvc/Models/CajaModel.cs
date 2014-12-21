namespace ControlT.Mvc.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using EF;

    public class CajaModel
    {
        public CajaModel(Caja caja)
        {
            this.CajaID = caja.CajaID;
            this.Nombre = caja.Nombre;

            var movimientosOrdenados = caja.Movimientos.OrderBy(x => x.Fecha);
            var saldoAnterior = movimientosOrdenados.Skip(10).Sum(x => x.Importe);

            this.UltimosMovimientos = new List<MovimientoModel>();
            foreach (var movimiento in movimientosOrdenados.Take(10))
            {
                saldoAnterior += movimiento.Importe;
                var model = new MovimientoModel(movimiento, saldoAnterior);
                this.UltimosMovimientos.Add(model);
            }
        }

        public int CajaID { get; set; }

        public string Nombre { get; set; }
        public List<MovimientoModel> UltimosMovimientos { get; set; }
    }
}