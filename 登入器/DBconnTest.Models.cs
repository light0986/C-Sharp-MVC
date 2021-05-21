using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{

    public class MS_PRODUCT
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public int PRICE { get; set; }
        public int QUANTITY { get; set; }
    }

    public class MS_ACCOUNT
    {
        public string ACCOUNT { get; set; }
        public string PASSWORD { get; set; }
    }
}
