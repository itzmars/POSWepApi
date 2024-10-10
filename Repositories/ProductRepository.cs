using Microsoft.EntityFrameworkCore;
using POSWebApi.Data;
using POSWebApi.Models;
using POSWebApi.Repositories.IRepositories;

namespace POSWebApi.Repositories{
    public class ProductRepository : IProductRepository
    {
        private readonly POSDbContext _context;

        public ProductRepository(POSDbContext context){
            _context = context;
        }
        public async Task CreateProductAsync(Product product)
        {
            if(product.Id == Guid.Empty){
                product.Id = Guid.NewGuid();
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            var existingProduct = await _context.Products.FindAsync(product.Id);
            if(existingProduct == null){
                throw new KeyNotFoundException("error");
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;

            _context.Products.Update(existingProduct);
            await _context.SaveChangesAsync();
        }

        
        public async Task DeleteProductAsync(Guid id)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if(existingProduct == null){
                throw new KeyNotFoundException("error");
            }

            _context.Products.Remove(existingProduct);
            await _context.SaveChangesAsync();

        }

    }
}