using System;
using System.Collections.Generic;
using System.Text;

namespace Telenor.Dal.Interfaces
{
    public interface IProductDal
    {
        DbEntities.Product GetProductById(int productId);
        IEnumerable<DbEntities.Product> GetAllProducts();
    }
}
