using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LearnITStore.Domain.Entities;

namespace LearnITStore.WebUI.Models
{    
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PageInfo PageInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}