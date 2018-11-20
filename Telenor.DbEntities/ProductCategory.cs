using System;
using System.Collections.Generic;
using System.Text;

namespace Telenor.DbEntities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
        public ProductCategory ParentCategory { get; set; }
    }
}
