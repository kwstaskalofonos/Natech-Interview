using Natech.Repository.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Natech.Repository.Interfaces
{
    public interface ISaleRepository
    {
        Task<ICollection<SaleDTO>> GetAll();
        Task<SaleDTO> Create(SaleDTO sale);
        Task<SaleDTO> Delete(long id);
        Double Sum();
    }
}
