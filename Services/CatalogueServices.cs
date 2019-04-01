using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using CataloguesCore.Entity;
using CataloguesCore.Interfaces;
using Mapster;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CataloguesCore.Services
{
    public class CatalogueServices : ICatalogues
    {
        private readonly ILogger<CatalogueServices> _logger;
        private readonly IAsyncRepository<Catalogue> _catalogRepository;
        private readonly IUriComposer _uriComposer;
        //private CataloguesMapper _Mapper = new CataloguesMapper();

        public CatalogueServices(
            IAsyncRepository<Catalogue> CatalogRepository,
            IUriComposer uriComposer,
            ILogger<CatalogueServices> logger)
        {
            _catalogRepository = CatalogRepository;
            _uriComposer = uriComposer;
            _logger = logger;
        }

        public async Task<IEnumerable<CataloguesDTO>> GetAllCatalouges()
        {
            _logger.LogInformation("GetCatalogs called.");
            var ListOfData = await _catalogRepository.ListAllAsync().ConfigureAwait(false);
            ListOfData.ForEach(x =>
            {
                if(x.PictureUri != null)
                    x.PictureUri = _uriComposer.ComposePicUri(x.PictureUri);
            });

            var destObject = ListOfData.Adapt<IEnumerable<CataloguesDTO>>();

            return destObject;// _Mapper.MapListCatalogueToListCatalogsDTO(ListOfData);
        }

        public async Task<CataloguesDTO> GetCatalougesById(int Id)
        {
            _logger.LogInformation("GetCatalougesById called. with Id:" + Id);
            var ListOfData = await _catalogRepository.GetByIdAsync(Id).ConfigureAwait(false);
            ListOfData.PictureUri = _uriComposer.ComposePicUri(ListOfData.PictureUri);
            var destObject = ListOfData.Adapt<CataloguesDTO>();

            return destObject;// _Mapper.MapSingleCatalogueToSingleCatalogsDTO(ListOfData);
        }


        public async Task<bool> AddUpdateCatalouge(CataloguesDTO _CataloguesDTO)
        {
            try
            {
                Catalogue _Catalogue = _CataloguesDTO.Adapt<Catalogue>(); // _Mapper.MapCatalogsDTOToCatalogue(_CataloguesDTO);
                if(_Catalogue.Id == 0)
                {
                    _logger.LogInformation("AddUpdateCatalouge called. ID:" + _CataloguesDTO.Id);
                    await _catalogRepository.AddAsync(_Catalogue);
                }
                else
                {
                    _logger.LogInformation("AddUpdateCatalouge called. ID:" + _CataloguesDTO.Id);
                    await _catalogRepository.UpdateAsync(_Catalogue);
                }

                return true;
            }
            catch (Exception)
            { 
                throw;
            }
        }

        public async Task<bool> DeleteCatalougeById(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    _logger.LogInformation("DeleteCatalougeById called. ID:" + Id);
                    var  Data = await _catalogRepository.GetByIdAsync(Id).ConfigureAwait(false);
                    if (Data != null)
                    {
                        await _catalogRepository.DeleteAsync(Data);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
         }
    }
}
