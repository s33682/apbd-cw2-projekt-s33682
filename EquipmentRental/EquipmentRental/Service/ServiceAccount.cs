using EquipmentRental.Account;

namespace EquipmentRental.Service;

public class ServiceAccount
{
    private Database _db;
    private User _currentUser;
    
    public ServiceAccount(Database db)
    {
        _db = db;
        _currentUser = null;
    }

    public void RegisterStudent(string name, string surname, string username, string password)
    {
        _db.AddUser(new Student(_db.GetNewAccountId(), name, surname, username, password));
    }
    
    public void RegisterEmployee(string name, string surname, string username, string password)
    {
        _db.AddUser(new Employee(_db.GetNewAccountId(), name, surname, username, password));
    }

    public bool Login(string username, string password)
    {
        User user = _db.Login(username, password);
        if (user != null)
        {
            _currentUser = user;
            return true;
        }
        return false;
    }

    public void Logout()
    {
        _currentUser = null;
    }

    public User GetCurrentUser()
    {
        return _currentUser;
    }

    public User GetUserById(int userid)
    {
        return _db.GetUser(userid);
    }
}