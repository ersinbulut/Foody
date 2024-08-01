using Foody.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Foody.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult ProductList()
        {
            var value = _productService.TGetAll();
            return View(value);
        }

        public IActionResult ProductListWithCategory()
        {
            return View();
        }
    }
}
