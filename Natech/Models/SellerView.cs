using Natech.Repository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Natech.Models
{
    public class SellerView
    {
        public ICollection<SellerDTO> sellers { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public long SellerId {get; set;}
    }
}
