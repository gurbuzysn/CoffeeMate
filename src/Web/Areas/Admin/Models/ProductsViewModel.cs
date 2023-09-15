using ApplicationCore.Entities;

namespace Web.Areas.Admin.Models
{
    public class ProductsViewModel
    {
        public List<Product> Products { get; set; } = new();
    }
}
