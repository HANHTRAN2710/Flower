using Flower.Models;
using Microsoft.EntityFrameworkCore;

namespace Flower.Services
{
    public class HomeServiceImpl : HomeService
    {
        private DatabaseContext db;
        public HomeServiceImpl(DatabaseContext _databaseContext)
        {
            db = _databaseContext;
        }

        public Product Find(int id)
        {
            return db.Products.Find(id);
        }

        public List<Models.Product> FindAll()
        {
            return db.Products.Where(p => p.Status==true).ToList();
        }

        //public List<Product> Findcart(int id) {
        //    {
        //        return db.Products.Where(p => p.Id == id).Select(p => new
        //        {
        //            Id = p.Id,
        //            Name = p.Name,
        //            Price = p.Price,
        //            Quantity = p.Quantity,
        //        }).FirstOrDefault()!;

        //    }

    public Models.Product Findid(int id)
        {
            return db.Products.Find(id);
        }

        public List<Models.Product> searchBykeyword(string keyword)
        {

            return db.Products.Where(p => p.Name.Contains(keyword)).ToList();
        }

        Product HomeService.Find(int id)
        {
            return FindAll().SingleOrDefault(p => p.Id == id);
        }

        Product HomeService.Findcart(int id)
        {
            return FindAll().SingleOrDefault(p => p.Id == id);

        }
    }
}
