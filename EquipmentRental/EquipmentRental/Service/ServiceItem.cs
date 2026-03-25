using EquipmentRental.Item;

namespace EquipmentRental.Service;

public class ServiceItem
{
    private Database db;
    
    public ServiceItem(Database db)
    {
        this.db = db;
    }

    public void AddLaptop(float price, string system, string cpu, string ram, string gpu, string disk)
    {
        db.AddDevice(new Laptop(db.GetNewItemId(), price, system, cpu, ram, gpu, disk));
    }

    public void AddProjector(float price, string resolution, int brightness)
    {
        db.AddDevice(new Projector(db.GetNewItemId(), price, resolution, brightness));
    }

    public void AddCamera(float price, string lens, int sdCardSize)
    {
        db.AddDevice(new Camera(db.GetNewItemId(), price, lens, sdCardSize));
    }

    public Device GetItemById(int itemId)
    {
        return db.GetItem(itemId);
    }
    
    public void ItemToService(int itemId)
    {
        var device = GetItemById(itemId);
        if (device != null)
        {
            device.SetAvailability(false);
        }
    }
}