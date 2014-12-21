namespace ControlT.Mvc.Models
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class MovimientosModel
    {
        public MovimientosModel(IEnumerable<SelectListItem> cajas)
        {
            this.Cajas = cajas;
        }
        public IEnumerable<SelectListItem> Cajas { get; set; }
    }
}