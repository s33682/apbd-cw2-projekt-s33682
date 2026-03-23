namespace EquipmentRental.Item;

public class Device
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public float Price { get; private set; }
    public bool Availability { get; private set; }

    protected Device()
    {
        Id = 0;
        Name = "";
        Price = 0;
        Availability = false;
    }

    protected Device(int id, float price)
    {
        Id = id;
        Name = "Device";
        Price = price;
        Availability = true;
    }

    protected void SetName(string s)
    {
        Name = s;
    }

    public void SetAvailability(bool b)
    {
        Availability = b;
    }
}