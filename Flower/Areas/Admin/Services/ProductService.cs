using Flower.Models;
namespace Flower.Areas.Admin.Services
{
    public interface ProductService
    {
        public List<Product> findAll();
        public Product findById(int id);
        //public Product findsumproduct(int id);
        public List<Product> searchBykeyword(string keyword);
        public List<Product> searchBykeyCategoryId(int CategoryId);
        public bool Create(Product product);
        public Product findByIdNoTracking(int id);
        public bool Update(Product product);

    }
}
