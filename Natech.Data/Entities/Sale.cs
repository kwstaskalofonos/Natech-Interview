using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Natech.Data.Entities
{
    public class Sale
    {
        [Key]
        public long SaleId { get; set; }
        [Required]
        public double Amount { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd H:mm:ss}")]
        public DateTime SaleDate { get; set; }

        public long SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}
