using ApplicationCore.Entities;
using Web.Areas.Admin.Models;

namespace Web.Areas.Admin.Interfaces
{
    public interface IProductsViewModelService
    {
        public Task<ProductsViewModel> GetProductViewModelAsync();
    }
}
