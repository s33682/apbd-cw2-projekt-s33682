using EquipmentRental.Account;
using EquipmentRental.Item;


public class Rental
{
    public int RentalId { get; private set; }
    public User Who { get; private set; }
    public Device Item { get; private set; }
    public DateTime Date { get; private set; }
    public int Length { get; private set; }
    public bool InTime { get; private set; }

    public Rental(int rentalId, User who, Device item, DateTime date, int length)
    {
        RentalId = rentalId;
        Who = who;
        Item = item;
        Date = date;
        Length = length;
        InTime = true;
    }

}