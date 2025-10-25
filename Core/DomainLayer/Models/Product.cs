using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Product:BaseEntity<int>
    {
        public string? Name {  get; set; }
        public string? Description { get; set; }

        public string PictureURL { get; set; }=null!;
        public decimal Price {  get; set; } 
        #region Product Brand
        public int BrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        #endregion
        #region Product Type
        public int TypeId { get; set; }
        public ProductType ProductType { get; set; }
        #endregion

    }
}
