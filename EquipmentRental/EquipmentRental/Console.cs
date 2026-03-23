using EquipmentRental.Account;
using EquipmentRental.Item;

Database _database = new Database();

User dawid = new Student(1, "Dawid", "Ochnio", "spooky", "Dawid123");

_database.AddUser(dawid);

Console.Write("Login: ");
String username = Console.ReadLine() ?? "";
Console.Write("Password: ");
String password  = Console.ReadLine() ?? "";

Console.WriteLine(_database.Login(username, password));