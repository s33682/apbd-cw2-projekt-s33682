namespace EquipmentRental.Item;

public class Laptop : Device
{
    public string System { get; private set; }
    public string Cpu { get; private set; }
    public string Ram { get; private set; }
    public string Gpu { get; private set; }
    public string Disk { get; private set; }
    
    public Laptop(int id, float price, string system, string cpu, string ram, string gpu, string disk)
        : base(id, price)
    {
        SetName("Laptop");
        System = system;
        Cpu = cpu;
        Ram = ram;
        Gpu = gpu;
        Disk = disk;
    }
}