using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Transaction
    {
        public Guid ID { get; set; }

        /// <summary>
        /// Type = 1 : Buy
        /// Type = 2 : Sell
        /// </summary>
        public int Type { get; set; }
        public DateTime Date { get; set; }
        public string Cashier { get; set; }
        public string CustomerID { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public Int32 Quantity { get; set; }

    }
}
