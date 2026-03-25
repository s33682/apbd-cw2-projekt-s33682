namespace EquipmentRental.Service;
using Item;

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
            Console.WriteLine($"{rental.Id}: Rented {rental.Item.Name} for {rental.Length}");
        }
        return true;
    }
}