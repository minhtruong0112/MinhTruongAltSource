using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TransactionDetail
    {
        public Guid TransactionID { get; set; }
        public Guid ID { get; set; }
        public string ProductID { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public Int32 Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }

    }
}
