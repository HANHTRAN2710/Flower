using Flower.Models;

namespace Flower.Services;

public class AccountServiceImpl : AccountService
{
    private DatabaseContext db;
    public AccountServiceImpl(DatabaseContext _dbContext)
    {
        db = _dbContext;
    }

    public bool CheckUsername(string username)
    {
        return db.Accounts.Count(a => a.Username == username) > 0;
    }

    public bool Create(Account account)
    {
        try
        {
            db.Accounts.Add(account);
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    public Account find(string username)
    {
        return db.Accounts.SingleOrDefault(a => a.Username == username);
    }

    public List<Account> findAll()
    {
        return db.Accounts.ToList();
    }

   

    public bool Login(string username, string password)
    {
        var account = db.Accounts.SingleOrDefault(a => a.Username == username && a.Status == true);
        if (account != null)
        {
            return BCrypt.Net.BCrypt.Verify(password, account.Password);
        }
        return false;
    }

}
