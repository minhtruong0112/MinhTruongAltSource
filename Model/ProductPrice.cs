using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProductSellPrice
    {
        public Guid ID { get; set; }

        public string ProductID { get; set; }

        public DateTime DateApply { get; set; }
        
        public decimal  Price { get; set; }

    }
}
