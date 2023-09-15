using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Web.Areas.Admin.Interfaces;
using Web.Areas.Admin.Models;

namespace Web.Areas.Admin.Services
{
    public class ProductsViewModelService : IProductsViewModelService
    {
        private readonly IRepository<Product> _productRepo;

        public ProductsViewModelService(IRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<ProductsViewModel> GetProductViewModelAsync()
        {
            var products = await _productRepo.GetAllAsync();

            ProductsViewModel viewModel = new ProductsViewModel()
            {
                Products = products
            };

            return viewModel;
        }
    }
}
