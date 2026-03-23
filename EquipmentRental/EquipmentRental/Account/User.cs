namespace EquipmentRental.Account;

public class User
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Type { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    

    protected User()
    {
        Id = 0;
        Name = "";
        Surname = "";
        Type = "User";
        Username = "";
        Password = "";
    }

    protected User(int id, string name, string surname, string username, string password)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Type = "User";
        Username = username;
        Password = password;
    }
    
    protected void SetType(string s)
    {
        Type = s;
    }
}