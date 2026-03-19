namespace EquipmentRental;

public class Projector : Device
{
    public string Resolution { get; private set; }

    public Projector(float price, string resolution)
        : base(price)
    {
        SetName("Projector");
        Resolution = resolution;
    }
}