using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Web.Interfaces;
using Web.Models;

namespace Web.Services
{
    public class HomeViewModelService : IHomeViewModelService
    {
        private readonly IRepository<Product> _productRepo;

        public HomeViewModelService(IRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<HomeViewModel> GetHomeViewModelAsync()
        {
            var products = await _productRepo.GetAllAsync();

            var homeViewModel = new HomeViewModel()
            {
                Products = products.Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    PictureUri = p.PictureUri,
                    Price = p.Price
                }).ToList()
            };

            return homeViewModel;
        }
    }
}
