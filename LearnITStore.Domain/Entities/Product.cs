using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LearnITStore.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }

        [Display(Name = "Nombre:"),
         Required(ErrorMessage = "Ingrese el nombre")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText),
        Required(ErrorMessage = "Ingrese la descripción")]
        [Display(Name = "Descripción:")]
        public string Description { get; set; }
        [Display(Name = "Precio:"),
            Required(ErrorMessage = "Ingrese el Precio")
            ,Range(0.01,99999,ErrorMessage = "Escriba un precio válido")]
        public decimal Price { get; set; }
        [Display(Name = "Categoría:"),
         Required(ErrorMessage = "Ingrese la categoría")]
        public string Category { get; set; }
    }
}
