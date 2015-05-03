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
            this.EsEditable = true;
        }

        public MovimientoModel(DateTime fecha, decimal saldoAnterior)
        {
            this.Fecha = fecha;
            this.Concepto = "Saldo Anterior";
            this.Importe = saldoAnterior;
            this.Saldo = saldoAnterior;
            this.EsExtraordinario = false;
            this.EsEditable = false;
        }

        public DateTime Fecha { get; set; }

        public string Concepto { get; set; }

        public decimal Importe { get; set; }

        public decimal Saldo { get; set; }

        public bool EsExtraordinario { get; set; }

        public bool EsEditable { get; set; }

        public string CssClass
        {
            get
            {
                return this.EsExtraordinario ? "highlight" : string.Empty;
            }
        }
    }
}