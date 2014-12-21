namespace ControlT.EF
{
    using System.Data.Entity;

    public class ControlTContext : DbContext
    {
        public ControlTContext()
            : base("ControlTContext")
        {
            Database.SetInitializer(new CajasInitializer());
        }

        public DbSet<Caja> Cajas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        public DbSet<CentroCostos> CentrosCostos { get; set; }
    }
}