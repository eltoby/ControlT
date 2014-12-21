namespace ControlT.EF
{
    using System;
    using System.Collections.ObjectModel;
    using System.Data.Entity;

    public class CajasInitializer : DropCreateDatabaseAlways<ControlTContext>
    {
        protected override void Seed(ControlTContext context)
        {
            var caja = new Caja {CajaID = 1, Nombre = "Cajita"};
            var movimiento = new Movimiento
            {
                Concepto = "Prueba",
                EsExtraordinario = false,
                Fecha = DateTime.Today,
                Importe = 1000M
            };

            var movimientoExtraordinario = new Movimiento
            {
                Concepto = "Movimiento Extraordinario",
                EsExtraordinario = true,
                Fecha = DateTime.Today,
                Importe = 2000M
            };

            caja.Movimientos = new Collection<Movimiento> { movimiento, movimientoExtraordinario };
            context.Cajas.Add(caja);

            base.Seed(context);
        }
    }
}