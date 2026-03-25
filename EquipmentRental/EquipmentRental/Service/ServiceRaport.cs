namespace EquipmentRental.Service;
using Item;

public class ServiceRaport
{
    private Database db;
    
    public ServiceRaport(Database db)
    {
        this.db = db;
    }

    public void PrintExpiredRentals()
    {
        List<Rental> rentals = db.GetExpiredRentals();
        foreach (Rental rental in rentals)
        {
            Console.WriteLine($"{rental.Id}: {rental.Who.Username} rented {rental.Item.Name} ({rental.Item.Id}) on {rental.Date} (Delayed by {(DateTime.Now - rental.Date.AddDays(rental.Length)).Days} days)");
        }
    }

    public void PrintAvailableItems()
    {
        List<Device> devices = db.GetAvailableDevices();
        foreach (Device device in devices)
        {
            Console.WriteLine($"{device.Id}: {device.Name} for {device.Price}$/day");
        }
    }

    public void PrintUserActiveRentals(int userId)
    {
        List<Rental> rentals = db.GetUserActiveRentals(userId);
        foreach (Rental rental in rentals)
        {
            Console.WriteLine($"{rental.Id}: Rented {rental.Item.Name} for {rental.Length}");
        }
    }
}