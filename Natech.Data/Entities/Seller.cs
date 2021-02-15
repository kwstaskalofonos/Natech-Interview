using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Natech.Data.Entities
{
    public class Seller
    {
        [Key]
        public long SellerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SurName { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
