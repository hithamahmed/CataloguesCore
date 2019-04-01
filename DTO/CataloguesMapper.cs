using ApplicationCore.Entities;
using CataloguesCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CataloguesCore
{
    public class CataloguesMapper
    {
        public CataloguesDTO MapSingleCatalogueToSingleCatalogsDTO(Catalogue entity)
        {
            CataloguesDTO _map = new CataloguesDTO();
            _map = (new CataloguesDTO()
            {
                Id = entity.Id,
                Name = entity.Name,
                PictureUri = entity.PictureUri,
                Status = entity.Status
            });
            return _map;
        }

        public List<CataloguesDTO> MapListCatalogueToListCatalogsDTO(IEnumerable<Catalogue> entity)
        {
            List<CataloguesDTO> _map = new List<CataloguesDTO>();
            foreach (var item in entity)
            {
                _map.Add(new CataloguesDTO()
                {
                    Id = item.Id,
                    Name = item.Name ,
                    PictureUri = item.PictureUri,
                    Status = item.Status,
 
                });
            }
            return _map;
        }

        public Catalogue MapCatalogsDTOToCatalogue(CataloguesDTO entity)
        {
            Catalogue _map = new Catalogue();
            _map = (new Catalogue()
            {
                Id = entity.Id,
                Name = entity.Name,
                PictureUri = entity.PictureUri,
                Status = entity.Status,
                CreatedAt = entity.CreatedAt,
                lastModifiedAt = entity.lastModifiedAt
            });
            return _map;
        }

    }
}
