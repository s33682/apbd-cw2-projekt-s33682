namespace EquipmentRental.Account;

public class Student : User
{
    
    public Student(int id, string name, string surname,  string username, string password)
        : base(id, name, surname,  username, password)
    {
        SetType("Student");
    }
}