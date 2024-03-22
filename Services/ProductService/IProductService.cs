namespace Web_API_CRUD.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();

        Task<Product?> GetSingleProduct(int id);

        Task<List<Product>> AddProduct(Product product);

        Task<List<Product>?> UpdateProduct(Product request);

        Task<List<Product>?> DeleteProduct(int id);
    }
}
