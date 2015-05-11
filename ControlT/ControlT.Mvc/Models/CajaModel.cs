namespace ControlT.Mvc.Models
{
    using EF;

    public class CajaModel
    {
        public CajaModel()
        {            
        }

        public CajaModel(Caja caja)
        {
            this.Nombre = caja.Nombre;
        }

        public string Nombre { get; set; }
    }
}