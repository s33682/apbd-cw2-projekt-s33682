namespace EquipmentRental.Service;

public class ServiceAccount
{
    private Database db;
    
    public ServiceAccount(Database db)
    {
        this.db = db;
    }
}