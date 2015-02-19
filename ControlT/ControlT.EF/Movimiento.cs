namespace ControlT.EF
{
    using System;

    public class Movimiento
    {
        public int MovimientoID { get; set; }

        public Caja Caja { get; set; }

        public int CajaID { get; set; }

        public CentroCostos CentroCostos { get; set; }

        public int? CentroCostosID { get; set; }

        public decimal Importe { get; set; }

        public string Concepto { get; set; }
        
        public DateTime Fecha { get; set; }

        public bool EsExtraordinario { get; set; }
    }
}