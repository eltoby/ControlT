namespace ControlT.EF
{
    using System.Collections.Generic;

    public class Caja
    {
        public int CajaID { get; set; }

        public string Nombre { get; set; }
        
        public ICollection<Movimiento> Movimientos { get; set; }
    }
}