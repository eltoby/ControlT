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
                Importe = 1000M,
                CajaID = 1
            };

            var movimientoExtraordinario = new Movimiento
            {
                Concepto = "Movimiento Extraordinario",
                EsExtraordinario = true,
                Fecha = DateTime.Today,
                Importe = 2000M,
                CajaID = 1
            };

            caja.Movimientos = new Collection<Movimiento> { movimiento, movimientoExtraordinario };
            context.Cajas.Add(caja);

            var banco = new Caja() { CajaID = 2, Nombre = "Banco Macro" };

            var movimientoBanco = new Movimiento()
            {
                Concepto = "Transferencia",
                EsExtraordinario = false,
                Fecha = DateTime.Today,
                Importe = 5000M,
                CajaID = 2
            };

            var salidaBanco = new Movimiento()
            {
                Concepto = "Pago por débito",
                EsExtraordinario = false,
                Fecha = DateTime.Today,
                Importe = -500,
                CajaID = 2
            };

            banco.Movimientos = new Collection<Movimiento>();
            banco.Movimientos.Add(movimientoBanco);
            banco.Movimientos.Add(salidaBanco);

            context.Cajas.Add(banco);

            base.Seed(context);
        }
    }
}