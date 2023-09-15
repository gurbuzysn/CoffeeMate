using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Interfaces;

namespace Web.Areas.Admin.Controllers
{
    public class ProductsController : AdminBaseController
    {
        private readonly IProductsViewModelService _productsViewModelService;

        public ProductsController(IProductsViewModelService productsViewModelService)
        {
            _productsViewModelService = productsViewModelService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productsViewModelService.GetProductViewModelAsync());
        }
    }
}
