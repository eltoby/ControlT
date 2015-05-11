namespace ControlT.Mvc.Models
{
    using System.Collections.Generic;
    using EF;

    public class CajasModel
    {
        private readonly List<CajaModel> cajas;

        public CajasModel(IEnumerable<Caja> cajas)
        {
            this.cajas = new List<CajaModel>();
            foreach (var caja in cajas)
                this.cajas.Add(new CajaModel(caja));
        }

        public IEnumerable<CajaModel> Cajas
        {
            get
            {
                return this.cajas.ToArray();
            }
        }
    }
}