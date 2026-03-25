namespace EquipmentRental.Service;
using Item;
using Account;

public class ServiceRaport
{
    private Database db;
    
    public ServiceRaport(Database db)
    {
        this.db = db;
    }

    public bool PrintExpiredRentals()
    {
        List<Rental> rentals = db.GetExpiredRentals();

        if (rentals.Count == 0)
        {
            Console.WriteLine("No expired rentals.");
            return  false;
        }

        foreach (Rental rental in rentals)
        {
            Console.WriteLine($"{rental.Id}: {rental.Who.Username} rented {rental.Item.Name} ({rental.Item.Id}) on {rental.Date} (Delayed by {(DateTime.Now - rental.Date.AddDays(rental.Length)).Days} days)");
        }
        return true;
    }

    public bool PrintAvailableItems()
    {
        List<Device> devices = db.GetAvailableDevices();

        if (devices.Count == 0)
        {
            Console.WriteLine("No available devices.");
            return false;
        }
        
        foreach (Device device in devices)
        {
            Console.WriteLine($"{device.Id}: {device.Name} for {device.Price}$/day");
        }
        return true;
    }

    public bool PrintAllItems()
    {
        List<Device> devices = db.GetAllDevices();

        if (devices.Count == 0)
        {
            Console.WriteLine("No available devices.");
            return false;
        }

        foreach (Device device in devices)
        {
            string status = device.Availability?"Available":"Unavailable";
            Console.WriteLine($"{device.Id}: {device.Name} for {device.Price}$/day [ {status} ]");
        }
        return true;
    }

    public bool PrintAllUsers()
    {
        List<User> users = db.GetAllUsers();

        if (users.Count == 0)
        {
            Console.WriteLine("No available users.");
            return false;
        }

        foreach (User user in users)
        {
            Console.WriteLine($"{user.Id}: {user.Name} {user.Surname} [ {user.Username} ]");
        }
        return true;
    }

    public void PrintSummary()
    {
        int countItems = db.CountDevices();
        int countAvailableItems = db.CountAvailableDevices();
        int countUsers = db.CountUsers();
        int countRentals = db.CountRentals();
        int countActiveRentals = db.CountActiveRentals();
        
        Console.WriteLine($"Total items: {countItems} [Available: {countAvailableItems}]");
        Console.WriteLine($"Total users: {countUsers}");
        Console.WriteLine($"Total rentals: {countRentals} [Active: {countActiveRentals}]");
    }

    public bool PrintUserActiveRentals(int userId)
    {
        List<Rental> rentals = db.GetUserActiveRentals(userId);

        if (rentals.Count == 0)
        {
            Console.WriteLine("No active rentals.");
            return false;
        }

        foreach (Rental rental in rentals)
        {
            Console.WriteLine($"{rental.Id}: Rented {rental.Item.Name} for {rental.Length} days");
        }
        return true;
    }
}