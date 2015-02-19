namespace ControlT.Mvc.Models
{
    using System;

    public class NuevoMovimientoModel
    {
        public string TipoMovimiento { get; set; }
        
        public string Fecha { get; set; }

        public int CajaID { get; set; }
        
        public decimal Importe { get; set; }
        
        public string Concepto { get; set; }
    }
}