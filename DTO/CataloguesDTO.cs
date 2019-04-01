using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CataloguesCore
{
    public class CataloguesDTO : EntityBase
    {
        public string Name { get; set; }
        public string PictureUri { get; set; }
 
    }
}

