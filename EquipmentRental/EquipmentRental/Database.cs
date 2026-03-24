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

    
    
    public User GetUser(int userId)
    {
        foreach (var user in Users)
        {
            if (user.Id == userId)
            {
                return user;
            }
        }
        return null;
    }
    public Device GetItem(int itemId)
    {
        foreach (var device in Devices)
        {
            if (device.Id == itemId)
            {
                return device;
            }
        }
        return null;
    }
    public Rental GetRental(int rentalId)
    {
        foreach (var rental in Rentals)
        {
            if (rental.Id == rentalId)
            {
                return rental;
            }
        }
        return null;
    }
    
    
    

    public List<Rental> GetUserActiveRentals(int userId)
    {
        List<Rental> UserRentals = new List<Rental>();

        foreach (var item in Rentals)
        {
            if (item.Who.Id == userId && item.IsActive)
            {
                UserRentals.Add(item);
            }
        }
        return UserRentals;
    }

    public List<Rental> GetExpiredRentals()
    {
        List<Rental> expired = new List<Rental>();
        foreach (var rental in Rentals)
        {
            if (rental.Date.AddDays(rental.Length) < DateTime.Now && rental.IsActive)
            {
                expired.Add(rental);
            }
        }
        return expired;
    }


    public int GetNewItemId()
    {
        int max = 0;
        foreach (var a in Devices)
        {
            if(a.Id > max)
            {
                max = a.Id;
            }
        }
        return max+1;
    }
    public int GetNewRentalId()
    {
        int max = 0;
        foreach (var a in Rentals)
        {
            if(a.Id > max)
            {
                max = a.Id;
            }
        }
        return max+1;
    }
    
    public int GetNewAccountId()
    {
        int max = 0;
        foreach (var a in Users)
        {
            if(a.Id > max)
            {
                max = a.Id;
            }
        }
        return max+1;
    }
    
    
    

    public User Login(string userName, string password)
    {
        for (int i=0; i<Users.Count; i++){
            if (userName.Equals(Users[i].Name))
            {
                if (password.Equals(Users[i].Password))
                {
                    return Users[i];
                }
            }
        }
        return null;
    }
}