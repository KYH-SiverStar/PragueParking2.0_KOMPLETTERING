using ConsoleApp.Models;
using Spectre.Console;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var garage = new ParkingGarage();
            bool running = true;

            while (running)
            {
                AnsiConsole.Write(new Markup("[bold yellow]Prague Parking System[/]\n"));
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an option")
                        .AddChoices("Park Vehicle", "Remove Vehicle", "Exit"));

                switch (choice)
                {
                    case "Park Vehicle":
                        var vehicleType = AnsiConsole.Prompt(
                            new SelectionPrompt<string>().Title("Select vehicle type")
                            .AddChoices("Car", "MC"));

                        string regNumber = AnsiConsole.Ask<string>("Enter registration number:");

                        Vehicle vehicle = vehicleType switch
                        {
                            "Car" => new Car(regNumber),
                            "MC" => new MC(regNumber),
                            _ => null
                        };
                        if (vehicle != null)
                        {
                            garage.ParkVehicle(vehicle);
                        }
                        break;

                    case "Remove Vehicle":
                        regNumber = AnsiConsole.Ask<string>("Enter registration number:");
                        garage.RemoveVehicle(regNumber);
                        break;

                    case "Exit":
                        running = false;
                        break;
                }
            }
        }
    }
}
