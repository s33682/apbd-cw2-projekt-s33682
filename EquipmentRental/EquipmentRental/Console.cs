
using EquipmentRental.Service;

var db = new Database();

var serviceAccount = new ServiceAccount(db);
var serviceItem = new ServiceItem(db);
var serviceRaport = new ServiceRaport(db);
var serviceRental = new ServiceRental(db);
