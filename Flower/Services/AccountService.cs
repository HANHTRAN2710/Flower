using Flower.Models;
namespace Flower.Services;

public interface AccountService
{
    public List<Account> findAll();
    public bool Create(Account account);
    public Account find(string username);
    public bool Login(string username, string password);
    public bool CheckUsername(string username);
}