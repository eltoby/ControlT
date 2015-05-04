namespace ControlT.Mvc.Models
{
    public class LineaResumenModel
    {
        public string NombreCaja { get; set; }

        public decimal Ingresos { get; set; }

        public decimal Egresos { get; set; }

        public decimal Total {
            get
            {
                return this.Ingresos - this.Egresos;
            }
        }
    }
}