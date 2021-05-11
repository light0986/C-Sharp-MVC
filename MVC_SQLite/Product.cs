using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace MVC01.Models
{
    [Table("PRODUCT")]
    public class Product
    {
        [Key]
        public int ID { get; set; }

        public string NAME { get; set; }

        public int PRICE { get; set; }

        public int QUANTITY { get; set; }
    }
}
