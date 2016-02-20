using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnITStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage ="Ingresa el nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Ingresa la dirección")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Ingresa la ciudad")]
        public string City { get; set; }
        [Required(ErrorMessage = "Ingresa el estado/departamento ")]
        public string State { get; set; }

        [Required(ErrorMessage = "Ingresa el código ZIP")]
        [RegularExpression(@"^\d{4,6}$",ErrorMessage ="Ingrese un ZIP válido")]
        public string ZIP { get; set; }
        [Required(ErrorMessage = "Ingresa el país")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
