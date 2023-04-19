using Flower.Models;

namespace Flower.Areas.Admin.Services
{
    public class CategoryServiceImpl: CategoryService
    {
        private DatabaseContext db;
        public CategoryServiceImpl(DatabaseContext _dbContext)
        {
            db = _dbContext;
        }

        public bool Create(Category category)
        {
            db.Categories.Add(category);
            return db.SaveChanges() > 0;
        }

        public List<Category> findAll()
        {
            return db.Categories.ToList();
        }

        public Category findById(int id)
        {
            return db.Categories.Find(id);
        }

        public List<Category> searchBykeyword(string keyword)
        {
            return db.Categories.Where(p => p.Name.Contains(keyword)).ToList();
        }

        public bool Update(Category category)
        {
            try
            {
                db.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
