using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CataloguesCore
{
    public class CatalogUriComposer : IUriComposer
    {
        private readonly CatalogueSettings _catalogueSettings;

        public CatalogUriComposer(CatalogueSettings catalogueSettings) => _catalogueSettings = catalogueSettings;

        public string ComposePicUri(string uriTemplate)
        {
            return uriTemplate.Replace("http://catalogbaseurltobereplaced", _catalogueSettings.CatalogueBaseUrl);
        }
    }
}
