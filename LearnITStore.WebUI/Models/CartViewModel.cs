using LearnITStore.Domain.Entities;

namespace LearnITStore.WebUI.Models
{
    public class CartViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}