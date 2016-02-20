using LearnITStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnITStore.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void Process(Cart cart, ShippingDetails shipping);
    }
}
