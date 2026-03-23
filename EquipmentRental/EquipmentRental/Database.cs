using EquipmentRental.Item;
using EquipmentRental.Account;

public class Database
{
    public List<Device> Devices  { get; private set; }
    public List<User> Users  { get; private set; }
    public List<Rental> Rentals  { get; private set; }

    public Database()
    {
        Devices = new List<Device>();
        Users = new List<User>();
        Rentals = new List<Rental>();
    }

    public void AddDevice(Device device)
    {
        Devices.Add(device);
    }
    public void AddUser(User user)
    {
        Users.Add(user);
    }

    public void AddRental(Rental rental)
    {
        Rentals.Add(rental);
    }

    public bool Login(string userName, string password)
    {
        for (int i=0; i<Users.Count; i++){
            if (userName.Equals(Users[i].Name))
            {
                if (password.Equals(Users[i].Password))
                {
                    return true;
                }
            }
        }
        return false;
    }
}