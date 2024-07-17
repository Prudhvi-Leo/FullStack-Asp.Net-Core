using Microsoft.AspNetCore.Mvc;
using TestWebApplication.Models;

namespace TestWebApplication.ViewComponents
{
    public class TopProductsViewComponent : ViewComponent
    {
        //The Invoke method for the View component
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            // Your logic for preparing data
            IProductsRepository productsRepository = new ProductsRepsitory();
            var products = await productsRepository.GetTopProductsAsync(count);
            return View(products);
        }
    }
}
