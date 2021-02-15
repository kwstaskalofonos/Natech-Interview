using Microsoft.EntityFrameworkCore;
using Natech.Data;
using Natech.Data.Entities;
using Natech.Repository.DTO;
using Natech.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Natech.Repository
{
    public class SellerRepository : ISellerRepository
    {
        private readonly DataContext _DataContext;
        public SellerRepository(DataContext context)
        {
            _DataContext = context;
        }

        public int Count()
        {
            return _DataContext.Sellers.Count();
        }

        public async Task<SellerDTO> Create(SellerDTO seller)
        {
            Seller entity = new Seller();

            entity.FirstName = seller.FirstName;
            entity.SurName = seller.SurName;

            _DataContext.Sellers.Add(entity);
            await _DataContext.SaveChangesAsync();

            return seller;
        }

        public async Task<SellerDTO> Delete(long id)
        {
            var returnDto = new SellerDTO();
            var seller = await _DataContext.Sellers
                .FindAsync(id);

            if(seller!=null)
            {
                _DataContext.Sellers.Remove(seller);
                await _DataContext.SaveChangesAsync();

                returnDto.FirstName = seller.FirstName;
                returnDto.SurName = seller.SurName;

                return returnDto;
            }
            return new SellerDTO();
        }

        public async Task<SellerDTO> Get(long id)
        {
            var returnDto = new SellerDTO();
            var seller = await _DataContext.Sellers
                .FindAsync(id);

            if (seller!=null)
            {
                returnDto.FirstName = seller.FirstName;
                returnDto.SurName = seller.SurName;
                returnDto.SellerId = seller.SellerId;
            }

            return returnDto;
        }

        public async Task<ICollection<SellerDTO>> GetAll()
        {
            var returnList = new List<SellerDTO>();
            var sellers = await _DataContext.Sellers
                .ToListAsync();

            if (sellers.Count > 0)
            {
                returnList = sellers.Select(q => new SellerDTO
                {
                    SellerId = q.SellerId,
                    FirstName = q.FirstName,
                    SurName = q.SurName
                }).ToList();
            }

            return returnList;
        }

        public async Task<SellerDTO> Update(SellerDTO seller)
        {
            var returnSeller = _DataContext.Sellers.SingleOrDefault(q => q.SellerId == seller.SellerId);
            if (seller != null)
            {
                returnSeller.FirstName = seller.FirstName;
                returnSeller.SurName = seller.SurName;

                //returnSeller.State = Microsoft.EntityFrameworkCore.EntityState.Modified
                _DataContext.Update(returnSeller);

                await _DataContext.SaveChangesAsync();
                return seller;
            }
            else
            {
                return new SellerDTO();
            }
        }
    }
}
