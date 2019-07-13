using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product
    {
        public string ID { get; set; }

        public Guid ProductCategoryID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public string Property { get; set; }
       

        public int? DisplayOrder { get; set; }

        public bool  IsUsed { get; set; }

    }
}
