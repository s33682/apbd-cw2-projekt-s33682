namespace EquipmentRental.Item;

public class Projector : Device
{
    public string Resolution { get; private set; }
    public int Brightness { get; private set; }

    public Projector(int id, float price, string resolution, int brightness)
        : base(id, price)
    {
        SetName("Projector");
        Resolution = resolution;
        Brightness = brightness;
    }
}