# System wypożyczalni sprzętu (Projekt APBD)

# Instrukcja uruchomienia

Aplikację uruchamiamy w IDE przez główny plik `Program.cs`
lub poprzez terminal znajdując się w .\apbd-cw2-projekt-s33682\EquipmentRental\EquipmentRental używając komendy `dotnet run`

# Scenariusz demo

Na start w kodzie zostały dodane domyślnie do bazy dane testowe.
6 Urządzeń, 2 konta i jedno wypożyczenie odrazu przedawnione.

Konto studenta: student:student123 (Student ma przedawnione wypożyczenie)
Konto pracownika: admin:admin123

# Krótki opis decyzji projektowych

Aplikacja ma jasną strukturę. Dzieli się na 3 warstwy.

Database: Przechowuje dane i odpowiada za operacje na czystych danych.
RentalCli: Odpowiada za wyświetlanie danych, tekstów, menu i sterowanie w konsoli.
Services: Podzielona na zestaw dedykowanych serwisów. Zajmuje się logiką i przetwarzaniem danych z bazą dla CLI.

Do obiektów urządzeń i kont zastosowałem klasy abstrakcyjne (Device i User), po których dziedziczą poszczególne urządzenia i konta.
Dzięki temu w bazie dane są trzymane w pojedyńczych listach z obiektamu typu Device i User.