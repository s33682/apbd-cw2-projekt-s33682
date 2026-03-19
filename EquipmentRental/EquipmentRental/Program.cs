using EquipmentRental;


var l1 = new Laptop(600, "Windows10", "i5-9600K", "16gb", "RTX2080", "SSD 1GB");

var p1 = new Projector(300, "1920x1080");

var c1 = new Camera(250, "50mm");

Console.WriteLine($"Device: {l1.Name}, Price: {l1.Price}, Availability: {l1.Availability}");
Console.WriteLine($"Device: {p1.Name}, Price: {p1.Price}, Availability: {p1.Availability}");
Console.WriteLine($"Device: {c1.Name}, Price: {c1.Price}, Availability: {c1.Availability}");

p1.SetAvailability(false);

Console.WriteLine($"Device: {p1.Name}, Price: {p1.Price}, Availability: {p1.Availability}");