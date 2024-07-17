using Microsoft.AspNetCore.Mvc;

namespace TestWebApplication.Models
{
    public class ProductsRepsitory : IProductsRepository
    {
        public async Task<List<Products>> GetTopProductsAsync(int count)
        {
            IEnumerable<Products> products = new List<Products>()
            {
                new Products { ProductID =1, Name ="Product 1", Category = "Category 1", Description ="Description 1", Price = 10m},
                new Products { ProductID =2, Name ="Product 2", Category = "Category 1", Description ="Description 2", Price = 20m},
                new Products { ProductID =3, Name ="Product 3", Category = "Category 1", Description ="Description 3", Price = 30m},
                new Products { ProductID =4, Name ="Product 4", Category = "Category 2", Description ="Description 4", Price = 40m},
                new Products { ProductID =5, Name ="Product 5", Category = "Category 2", Description ="Description 5", Price = 50m},
                new Products { ProductID =6, Name ="Product 6", Category = "Category 2", Description ="Description 6", Price = 50m}
            };
            //We are Delaying the Execution for 1 Seconds to get the Data from the database
            await Task.Delay(TimeSpan.FromSeconds(1));
            return products.Take(count).ToList();
        }
    }
}
