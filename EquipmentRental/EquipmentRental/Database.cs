using EquipmentRental.Item;
using EquipmentRental.Account;

public class Database
{
    public List<Device> _devices  { get; private set; }
    public List<User> _users  { get; private set; }
    public List<Rental> _rentals  { get; private set; }

    public Database()
    {
        _devices = new List<Device>();
        _users = new List<User>();
        _rentals = new List<Rental>();
    }

    public void AddDevice(Device device)
    {
        _devices.Add(device);
    }
    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void AddRental(Rental rental)
    {
        _rentals.Add(rental);
    }

    public bool Login(string userName, string password)
    {
        for (int i=0; i<_users.Count; i++){
            if (userName.Equals(_users[i].Name))
            {
                if (password.Equals(_users[i].Password))
                {
                    return true;
                }
            }
        }
        return false;
    }
}