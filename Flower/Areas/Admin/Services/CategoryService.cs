using Flower.Models;

namespace Flower.Areas.Admin.Services
{
    public interface CategoryService
    {
        public List<Category> findAll();
        public bool Create(Category category);
        public Category findById(int id);
        public bool Update(Category category);
        public List<Category> searchBykeyword(string keyword);


    }
}
