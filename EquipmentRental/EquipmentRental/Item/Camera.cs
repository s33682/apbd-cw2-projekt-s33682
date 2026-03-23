namespace EquipmentRental.Item;

public class Camera : Device
{
    public string Lens { get; private set; }
    public int SdCardSize  { get; private set; }

    public Camera(int id, float price, string lens, int  sdCardSize)
        : base(id, price)
    {
        SetName("Camera");
        Lens = lens;
        SdCardSize = sdCardSize;
    }
}    