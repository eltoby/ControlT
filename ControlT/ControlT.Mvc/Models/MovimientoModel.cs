namespace ControlT.Mvc.Models
{
    using System;
    using EF;

    public class MovimientoModel
    {
        public MovimientoModel(Movimiento movimiento, decimal saldo)
        {
            this.Fecha = movimiento.Fecha;
            this.Concepto = movimiento.Concepto;
            this.Importe = movimiento.Importe;
            this.Saldo = saldo;
            this.EsExtraordinario = movimiento.EsExtraordinario;
        }

        public DateTime Fecha { get; set; }

        public string Concepto { get; set; }

        public decimal Importe { get; set; }

        public decimal Saldo { get; set; }

        public bool EsExtraordinario { get; set; }

        public string CssClass
        {
            get
            {
                return this.EsExtraordinario ? "highlight" : string.Empty;
            }
        }
    }
}