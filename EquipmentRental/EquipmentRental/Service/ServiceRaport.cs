namespace EquipmentRental.Service;

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
}