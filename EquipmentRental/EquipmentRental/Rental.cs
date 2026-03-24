using EquipmentRental.Account;
using EquipmentRental.Item;


public class Rental
{
    public int Id { get; private set; }
    public User Who { get; private set; }
    public Device Item { get; private set; }
    public DateTime Date { get; private set; }
    public int Length { get; private set; }
    public bool InTime { get; private set; }
    public bool IsActive { get; private set; }

    public Rental(int id, User who, Device item, DateTime date, int length, bool isActive)
    {
        Id = id;
        Who = who;
        Item = item;
        Date = date;
        Length = length;
        InTime =  true;
        IsActive = isActive;
    }
    
    public void SetActive(bool b)
    {
        IsActive = b;
    }
    
    public void SetInTime(bool b)
    {
        InTime = b;
    }
}