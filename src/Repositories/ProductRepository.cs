using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.Models;

namespace Products.Repositories
{
    public class ProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> Get()
        {
            return await _context.Products
                .Include(x => x.Category)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.Include(x => x.Category).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Product>> GetByCategory(int id) 
        {
            return await _context.Products.AsNoTracking().Where(x => x.Category.Id == id).ToListAsync();
        }
        
        public async Task<Product> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

    }
}