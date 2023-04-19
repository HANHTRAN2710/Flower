using Flower.Areas.Admin.Models;
using System.Globalization;

namespace Flower.Areas.Admin.Services
{
    public class ProductServiceImpl: ProductService
    {
        public Product Find(int id)
        {
            return findAll().SingleOrDefault(p => p.Id == id);
        }

        public List<Product> findAll()
        {
            return new List<Product> {
                new Product()
                {
                    Id= 1,
                    Name = "Computer 1",
                    Photo = "155.png",
                    Created = DateTime.ParseExact("05/03/2023","dd/MM/yyyy",CultureInfo.InvariantCulture),
                    Price = 4.5
                },
                new Product()
                {
                    Id= 2,
                    Name = "Laptop 2",
                    Photo = "155.png",
                    Created = DateTime.ParseExact("22/03/2023","dd/MM/yyyy",CultureInfo.InvariantCulture),
                    Price = 65
                },
                new Product()
                {
                    Id= 3,
                    Name = "Computer 3",
                    Photo = "155.png",
                    Created = DateTime.ParseExact("26/10/2022","dd/MM/yyyy",CultureInfo.InvariantCulture),
                    Price = 20.5
                }
            };
        }

       

        public List<Product> findByKeyword(string keyword)
        {
            return findAll().Where(p => p.Name.Contains(keyword)).ToList();
        }

       
    }
}
