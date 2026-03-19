namespace EquipmentRental;

public class Camera : Device
{
    public string Lens { get; private set; }

    public Camera(float price, string lens)
        : base(price)
    {
        SetName("Camera");
        Lens = lens;
    }
}    