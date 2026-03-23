namespace EquipmentRental.Account;

public class Employee : User
{
    
    public Employee(int id, string name, string surname,  string username, string password)
        : base(id, name, surname,  username, password)
    {
        SetType("Employee");
    }
}