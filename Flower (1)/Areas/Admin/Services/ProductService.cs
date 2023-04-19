using Flower.Areas.Admin.Models;

namespace Flower.Areas.Admin.Services
{
    public interface ProductService
    {
        public List<Product> findAll();
        public Product Find(int id);
        public List<Product> findByKeyword(string keyword);
    }
}
