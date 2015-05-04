namespace ControlT.Mvc.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using EF;

    public class ResumenModel
    {
        private readonly List<LineaResumenModel> lineas;

        public ResumenModel(IEnumerable<Movimiento> movimientos)
        {
            this.lineas = new List<LineaResumenModel>();

            foreach (var grupoCaja in movimientos.GroupBy(x => x.Caja))
            {
                var linea = new LineaResumenModel
                {
                    NombreCaja = grupoCaja.Key.Nombre,
                    Ingresos = grupoCaja.Where(x => x.Importe > 0).Sum(x => x.Importe),
                    Egresos = grupoCaja.Where(x => x.Importe < 0).Sum(x => x.Importe)*-1
                };
                this.lineas.Add(linea);
            }
        }

        public IEnumerable<LineaResumenModel> Lineas
        {
            get
            {
                return this.lineas.ToArray();
            }
        }

        public decimal TotalIngresos
        {
            get
            {
                return this.lineas.Sum(x => x.Ingresos);
            }
        }

        public decimal TotalEgresos
        {
            get
            {
                return this.lineas.Sum(x => x.Egresos);
            }
        }

        public decimal Saldo
        {
            get
            {
                return this.TotalIngresos - this.TotalEgresos;
            }
        }
    }
}