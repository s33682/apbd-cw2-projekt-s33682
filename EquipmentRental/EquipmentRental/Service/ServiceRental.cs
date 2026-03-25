namespace EquipmentRental.Service;

public class ServiceRental
{
    private Database _db;
    private const int DelayPricePerDay = 10;
    private const int StudentRentalLimit = 2;
    private const int EmployeeRentalLimit = 5;
    
    public ServiceRental(Database _db)
    {
        this._db = _db;
    }

    public Rental GetRentalById(int rentalId)
    {
        return _db.GetRental(rentalId);
    }

    public void RentItem(int itemId, int userId, int duration)
    {
        var user = _db.GetUser(userId);
        var item = _db.GetItem(itemId);
        var userRental = _db.GetUserActiveRentals(userId);

        if (item.Availability)
        {
            if ((user.Type.Equals("Student") && userRental.Count < StudentRentalLimit) ||
                (user.Type.Equals("Employee") && userRental.Count < EmployeeRentalLimit))
            {
                _db.AddRental(new Rental(_db.GetNewRentalId(), user, item, DateTime.Now, duration, true));
                item.SetAvailability(false);
            }
        }
    }
    public int ReturnItem(int rentalId)
    {
        var rental = _db.GetRental(rentalId);
        var item = _db.GetItem(rental.Item.Id);
        
        var present = DateTime.Now;
        var lengthCount = present - rental.Date;
        
        int punishment = 0;

        if (lengthCount.Days > rental.Length)
        {
            rental.SetInTime(false);
            punishment = (lengthCount.Days - rental.Length) * DelayPricePerDay;
        }
        else
        {
            rental.SetInTime(true);
        }

        item.SetAvailability(true);
        rental.SetActive(false);
        return punishment;
    }

    public List<Rental> GetExpiredRentals()
    {
        return _db.GetExpiredRentals();
    }
}