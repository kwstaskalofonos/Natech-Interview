using Microsoft.EntityFrameworkCore;
using Natech.Data;
using Natech.Data.Entities;
using Natech.Repository.DTO;
using Natech.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Natech.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DataContext _DataContext;
        public SaleRepository(DataContext context)
        {
            _DataContext = context;
        }
        public async Task<SaleDTO> Create(SaleDTO sale)
        {
            Sale entity = new Sale();

            entity.Amount = sale.Amount;
            entity.SaleDate = DateTime.Now;
            entity.SellerId = sale.SellerId;

             _DataContext.Sales.Add(entity);
            await _DataContext.SaveChangesAsync();

            return sale;
        }

        public async Task<SaleDTO> Delete(long id)
        {
            var returnDto = new SaleDTO();
            var sale = await _DataContext.Sales
                .FindAsync(id);

            if (sale != null)
            {
                _DataContext.Sales.Remove(sale);
                await _DataContext.SaveChangesAsync();

                returnDto.Amount = sale.Amount;
                returnDto.SaleDate = sale.SaleDate;

                return returnDto;
            }
            return new SaleDTO();
        }

        public async Task<ICollection<SaleDTO>> GetAll()
        {
            var returnList = new List<SaleDTO>();
            var sales = await _DataContext.Sales
                .ToListAsync();

            if (sales.Count > 0)
            {
                returnList = sales.Select(q => new SaleDTO
                {
                    
                    Amount = q.Amount,
                    SaleDate = q.SaleDate,
                    SellerId = q.SellerId,
                    SaleId = q.SaleId,
                    SellerName = _DataContext.Sellers
                        .Where(c => c.SellerId==q.SellerId)
                        .Select(c => c.FirstName).SingleOrDefault(),
                    SellerSurName = _DataContext.Sellers
                        .Where(c => c.SellerId == q.SellerId)
                        .Select(c => c.SurName).SingleOrDefault()
                }).ToList();
            }

            return returnList;
        }

        public double Sum()
        {
            Double sum = 0.0;
            sum = _DataContext.Sales
                .Select(q => q.Amount)
                .Sum();

            return sum;
        }
    }
}
