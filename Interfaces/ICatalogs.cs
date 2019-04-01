using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CataloguesCore.Interfaces
{
    public interface ICatalogues
    {
        Task<IEnumerable<CataloguesDTO>> GetAllCatalouges();
        Task<CataloguesDTO> GetCatalougesById(int Id);
        Task<bool> AddUpdateCatalouge(CataloguesDTO _CataloguesDTO);
        Task<bool> DeleteCatalougeById(int Id);
    }
}
