using Microsoft.AspNetCore.Mvc.Rendering;
using Natech.Repository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Natech.Models
{
    public class SaleView
    {
        public ICollection<SaleDTO> sales { get; set; }
        public ICollection<SelectListItem> sellers { get; set; }
        public long SaleId { get; set; }
        public double Amount { get; set; }
        public DateTime SaleDate { get; set; }
        public long Seller { get; set; }
    }
}
