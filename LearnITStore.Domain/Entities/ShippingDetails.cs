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
        [Display(Name = "Nombre:")]
        public string Name { get; set; }

        [Display(Name = "Linea 1:")]
        [Required(ErrorMessage ="Ingresa la dirección")]
        public string Line1 { get; set; }
        
        [Display(Name = "Linea 2:")]
        public string Line2 { get; set; }

        [Display(Name = "Linea 3:")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Ingresa la ciudad")]
        [Display(Name = "Ciudad:")]
        public string City { get; set; }

        [Required(ErrorMessage = "Ingresa el estado/departamento ")]
        [Display(Name = "Estado/Provincia:")]
        public string State { get; set; }

        [Required(ErrorMessage = "Ingresa el código ZIP")]
        [Display(Name = "Código ZIP:")]
        [RegularExpression(@"^\d{4,6}$",ErrorMessage ="Ingrese un ZIP válido")]
        public string ZIP { get; set; }

        [Required(ErrorMessage = "Ingresa el país")]
        [Display(Name = "País:")]
        public string Country { get; set; }

        [Display(Name = "Envoltura de regalo:")]
        public bool GiftWrap { get; set; }
    }
}
