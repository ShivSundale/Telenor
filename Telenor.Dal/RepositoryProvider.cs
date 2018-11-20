using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Telenor.Dal.Interfaces;
using Telenor.Infrastructure;

namespace Telenor.Dal
{
    public class RepositoryProvider : IRepositoryProvider
    {
        private CatalogContext Context { get; }

        private IProductDal _productDal;
        public IProductDal ProductDal=> _productDal ?? (_productDal = new ProductDal(Context));

        public RepositoryProvider(CatalogContext context)
        {
            Context = context;
        }
    }
}
