using Flower.Models;
namespace Flower.Services;

public interface HomeService
{
    //Product thay the san pham cho home
    public List<Models.Product> FindAll();
    public Product Find(int id);
    public Product Findcart(int id);
    public Models.Product Findid(int id);
    public List<Models.Product> searchBykeyword(string keyword);

}
