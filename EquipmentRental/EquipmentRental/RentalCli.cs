using EquipmentRental.Service;
using EquipmentRental.Account;

namespace EquipmentRental;

public class RentalCli
{
    private Database _db;
    private ServiceAccount _serviceAccount;
    private ServiceRental _serviceRental;
    private ServiceItem _serviceItem;
    private ServiceRaport _serviceRaport;

    public RentalCli()
    {
        _db = new Database();
        _serviceAccount = new ServiceAccount(_db);
        _serviceItem = new ServiceItem(_db);
        _serviceRaport = new ServiceRaport(_db);
        _serviceRental = new ServiceRental(_db);
    }

    public void Start()
    {
        bool started  = true;

        while (started)
        {
            User current = _serviceAccount.GetCurrentUser();
            
            if (current == null)
            {
                Console.Clear();
                Console.WriteLine(" === Rental Services === ");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                
                Console.Write("Option: ");
                string choice = Console.ReadLine();
                Console.Clear();
                
                switch (choice)
                {
                    case "1":
                        LoginCli();
                        break;
                    case "2":
                        RegisterCli();
                        break;
                    case "3":
                        started = false;
                        break;
                    default:
                        Console.WriteLine(" Invalid choice, please try again! ");
                        break;
                }
            }
            else if (current != null && current.Type.Equals("Student"))
            {
                Console.Clear();
                Console.WriteLine(" === Rental Services === ");
                Console.WriteLine("1. Rent item");
                Console.WriteLine("2. Return item");
                Console.WriteLine("3. Logout");
                
                Console.Write("Option: ");
                string choice = Console.ReadLine();
                Console.Clear();
                
                switch (choice)
                {
                    case "1":
                        RentItemCli(current);
                        break;
                    case "2":
                        ReturnItemCli(current);
                        break;
                    case "3":
                        _serviceAccount.Logout();
                        break;
                    default:
                        Console.WriteLine(" Invalid choice, please try again! ");
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine(" === Rental Services === ");
                Console.WriteLine("1. Rent item");
                Console.WriteLine("2. Return item");
                Console.WriteLine("3. Add item to database");
                Console.WriteLine("4. Delayed rentals report");
                Console.WriteLine("5. Add Employee to database");
                Console.WriteLine("6. Logout");
                
                Console.Write("Option: ");
                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        RentItemCli(current);
                        break;
                    case "2":
                        ReturnItemCli(current);
                        break;
                    case "3":
                        AddItemCli(current);
                        break;
                    case "4":
                        DelayedRentalsCli();
                        break;
                    case "5":
                        AddEmployeeCli();
                        break;
                    case "6":
                        _serviceAccount.Logout();
                        break;
                    default:
                        Console.WriteLine(" Invalid choice, please try again! ");
                        break;
                }
            }
        }
    }

    private void LoginCli()
    {
        Console.WriteLine(" === Rental Services === ");
        Console.WriteLine(" ======== Login ======== ");
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();
        if (_serviceAccount.Login(username, password))
        {
            Console.WriteLine(" Login Successful! Press any enter to continue... ");
        }
        else
        {
            Console.WriteLine(" Login Failed! Press any enter to continue... ");
        }
        Console.ReadLine();
    }

    private void RegisterCli()
    {
        Console.WriteLine(" === Rental Services === ");
        Console.WriteLine(" ======  Register ====== ");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Surname: ");
        string surname = Console.ReadLine();
        Console.Write("Username: ");
        string usernameReg =  Console.ReadLine();
        Console.Write("Password: ");
        string passwordReg =  Console.ReadLine();
        _serviceAccount.RegisterStudent(name, surname, usernameReg, passwordReg);
        
        Console.WriteLine("Registered successfully! Press enter to continue...");
        Console.ReadLine();
    }

    private void RentItemCli(User current)
    {
        Console.WriteLine(" === Rental Services === ");
        Console.WriteLine(" ====== Rent Item ====== ");
        _serviceRaport.PrintAvailableItems();
        
        Console.Write("Enter item ID: ");
        string itemID = Console.ReadLine();
        int itemId = int.Parse(itemID);

        Console.Write("Enter duration in days: ");
        string duration = Console.ReadLine();
        int days = int.Parse(duration);
        
        _serviceRental.RentItem(itemId, current.Id, days);
        Console.WriteLine($"Item Rented! To pay: {_serviceItem.GetItemById(itemId).Price*days}. Press enter to continue...");
        Console.ReadLine();
    }

    private void ReturnItemCli(User current)
    {
        Console.WriteLine(" === Rental Services === ");
        Console.WriteLine(" ===== Return Item ===== ");
        _serviceRaport.PrintUserActiveRentals(current.Id);
        
        Console.Write("Enter rental ID: ");
        string rentalID = Console.ReadLine();
        int rentalId = int.Parse(rentalID);

        int punishment = _serviceRental.ReturnItem(rentalId);

        if (punishment > 0)
        {
            Console.WriteLine($"Item returned with delay! You have to pay for it: {punishment}");
        }
        else
        {
            Console.WriteLine("Item returned in time!");
        }
        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
    }

    private void AddItemCli(User current)
    {
        Console.WriteLine(" === Rental Services === ");
        Console.WriteLine(" ====== Add  Item ====== ");
        Console.WriteLine("1. Laptop");
        Console.WriteLine("2. Camera");
        Console.WriteLine("3. Projector");
        
        Console.Write("Option: ");
        string choice = Console.ReadLine();
        Console.Clear();

        switch (choice)
        {
            case "1":
                Console.WriteLine(" === Rental Services === ");
                Console.WriteLine(" ===== Add  Laptop ===== ");
                
                Console.Write("Price: ");
                string priceLapStr = Console.ReadLine();
                float priceLap = float.Parse(priceLapStr);
                
                Console.Write("System: ");
                string system = Console.ReadLine();
                
                Console.Write("Cpu: ");
                string cpu = Console.ReadLine();
                
                Console.Write("Ram: ");
                string ram = Console.ReadLine();
                
                Console.Write("Gpu: ");
                string gpu = Console.ReadLine();
                
                Console.Write("Disk: ");
                string disk = Console.ReadLine();
                
                _serviceItem.AddLaptop(priceLap, system, cpu, ram, gpu, disk);
                Console.WriteLine("Item added successfully! Press enter to continue... ");
                Console.ReadLine();
                break;
            case "2":
                Console.WriteLine(" === Rental Services === ");
                Console.WriteLine(" ====== Add  Camera ===== ");
                
                Console.Write("Price: ");
                string priceCamStr = Console.ReadLine();
                float priceCam = float.Parse(priceCamStr);
                
                Console.Write("Lens: ");
                string lens = Console.ReadLine();
                
                Console.Write("SD card size: ");
                string sdCardSizeStr = Console.ReadLine();
                int  sdCardSize = int.Parse(sdCardSizeStr);
                
                _serviceItem.AddCamera(priceCam, lens, sdCardSize);
                Console.WriteLine("Item added successfully! Press enter to continue... ");
                Console.ReadLine();
                break;
            case "3":
                Console.WriteLine(" === Rental Services === ");
                Console.WriteLine(" ==== Add  Projector === ");
                
                Console.Write("Price: ");
                string priceProjStr = Console.ReadLine();
                float priceProj = float.Parse(priceProjStr);
                
                Console.Write("Resolution: ");
                string resolution = Console.ReadLine();
                
                Console.Write("Brightness: ");
                string brightnessStr = Console.ReadLine();
                int  brightness = int.Parse(brightnessStr);
                
                _serviceItem.AddProjector(priceProj, resolution, brightness);
                Console.WriteLine("Item added successfully! Press enter to continue... ");
                Console.ReadLine();
                break;
            default:
                Console.WriteLine("Invalid choice! ");
                break;
        }
    }

    private void DelayedRentalsCli()
    {
        Console.WriteLine(" === Rental Services === ");
        Console.WriteLine(" === Delayed rentals === ");
        
        _serviceRaport.PrintExpiredRentals();
        
        Console.WriteLine("Press enter to continue... ");
        Console.ReadLine();
    }

    private void AddEmployeeCli()
    {
        Console.WriteLine(" === Rental Services === ");
        Console.WriteLine(" ==== Add  Employee ==== ");
        
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Surname: ");
        string surname = Console.ReadLine();
        Console.Write("Username: ");
        string usernameReg =  Console.ReadLine();
        Console.Write("Password: ");
        string passwordReg =  Console.ReadLine();
        
        _serviceAccount.RegisterEmployee(name, surname, usernameReg, passwordReg);
        Console.WriteLine("Employee added successfully! Press enter to continue...");
        Console.ReadLine();
    }
}