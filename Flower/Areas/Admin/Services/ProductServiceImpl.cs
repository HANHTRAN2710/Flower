using Flower.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Flower.Areas.Admin.Services
{
    public class ProductServiceImpl: ProductService
    {
        private DatabaseContext db;
        public ProductServiceImpl(DatabaseContext _dbContext)
        {
            db = _dbContext;
        }
        public List<Product> findAll()
        {
            return db.Products.ToList();
        }

        public Product findById(int id)
        {
            return db.Products.Find(id);
        }
        public List<Product> searchBykeyword(string keyword)
        {
            return db.Products.Where(p => p.Name.Contains(keyword)).ToList();
        }
        public List<Product> searchBykeyCategoryId(int CategoryId)
        {
            return db.Products.Where(p => p.CategoryId == CategoryId).ToList();
        }

        public bool Create(Product product)
        {
            db.Products.Add(product);
            return db.SaveChanges() > 0;
        }
        public bool Update(Product product)
        {
            try
            {
                db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
        public Product findByIdNoTracking(int id)
        {
            return db.Products.AsNoTracking().SingleOrDefault(p => p.Id == id);
        }

        //public Product findsumproduct(int id)
        //{
        //    return db.Products.Where()
        //}
    }
}
