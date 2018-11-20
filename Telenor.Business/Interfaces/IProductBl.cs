using System.Collections.Generic;
using System.Threading.Tasks;

namespace Telenor.Business.Interfaces
{
    public interface IProductBl
    {
        Task<IEnumerable<ViewModel.ProductViewModel>> GetAllProducts();
        Task<ViewModel.ProductViewModel> GetProductById(int productId);
    }
}
