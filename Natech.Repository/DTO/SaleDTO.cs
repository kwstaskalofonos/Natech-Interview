using System;
using System.Collections.Generic;
using System.Text;

namespace Natech.Repository.DTO
{
    public class SaleDTO
    {
        public long SaleId { get; set; }
        public double Amount { get; set; }
        public DateTime SaleDate { get; set; }
        public string SellerName { get; set; }
        public string SellerSurName { get; set; }
        public long SellerId { get; set; }
    }
}
