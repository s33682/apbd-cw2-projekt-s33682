namespace EquipmentRental;

public class Device
{
    public string Name { get; private set; }
    public float Price { get; private set; }
    public bool Availability { get; private set; }

    protected Device()
    {
        Name = "";
        Price = 0;
        Availability = false;
    }

    protected Device(float price)
    {
        Name = "Device";
        Price = price;
        Availability = true;
    }
    
    public void SetName(string s)
    {
        Name = s;
    }

    public void SetAvailability(bool b)
    {
        Availability = b;
    }
}