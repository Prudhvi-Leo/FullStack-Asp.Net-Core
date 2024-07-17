namespace TestWebApplication.Models
{
    public interface IProductsRepository
    {
        public Task<List<Products>> GetTopProductsAsync(int count);
    }
}
