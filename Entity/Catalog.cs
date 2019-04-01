using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CataloguesCore.Entity
{
    public class Catalogue : EntityBase
    {
        //Aplication Catalogue contans multiple categores

        [MaxLength(50)]
        public string Name { get; set; }
        public string PictureUri { get; set; }

    }
}
