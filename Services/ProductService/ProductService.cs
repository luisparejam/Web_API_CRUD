namespace Web_API_CRUD.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> AddProduct(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<List<Product>?> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return null;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product?> GetSingleProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return null;
            return product;
        }

        public async Task<List<Product>?> UpdateProduct(Product request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            if (product == null)
                return null;

            product.Brand = request.Brand;
            product.Category = request.Category;
            product.Code = request.Code;
            product.Description = request.Description;
            product.UnitCost = request.UnitCost;
            product.Status = request.Status;

            await _context.SaveChangesAsync();

            var products = await _context.Products.ToListAsync();
            return products;
        }
    }
}