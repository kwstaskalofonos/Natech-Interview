using Natech.Repository.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Natech.Repository.Interfaces
{
    public interface ISellerRepository
    {
        Task<ICollection<SellerDTO>> GetAll();
        Task<SellerDTO> Create(SellerDTO seller);
        Task<SellerDTO> Delete(long id);
        Task<SellerDTO> Update(SellerDTO seller);
        Task<SellerDTO> Get(long id);
        int Count();
    }
}
