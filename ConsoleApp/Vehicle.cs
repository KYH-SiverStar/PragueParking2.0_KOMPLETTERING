using System;

namespace ConsoleApp.Models
{
    public abstract class Vehicle
    {
        public string RegistrationNumber { get; set; }  // Ensure this is public
        public DateTime ArrivalTime { get; private set; }

        // Abstract property to be overridden in derived classes (Car, MC)
        public abstract int HourlyRate { get; }

        // Constructor to set the registration number and arrival time
        protected Vehicle(string registrationNumber)
        {
            RegistrationNumber = registrationNumber;
            ArrivalTime = DateTime.Now;
        }

        // Method to get parking duration based on current time minus arrival time
        public TimeSpan GetParkingDuration() => DateTime.Now - ArrivalTime;
    }
}




namespace ConsoleApp.Models  // Ensure the namespace is consistent with your other files
{
    public class Car : Vehicle
    {
        // Implement the abstract property from Vehicle, defining hourly rate for Cars
        public override int HourlyRate => 20;

        // Constructor passing the registration number to the base class (Vehicle)
        public Car(string registrationNumber) : base(registrationNumber) { }
    }
}






namespace ConsoleApp.Models  // Ensure consistency in namespaces across all files
{
    public class MC : Vehicle
    {
        // Implement the abstract property from Vehicle, defining hourly rate for motorcycles
        public override int HourlyRate => 10;

        // Constructor passing the registration number to the base class (Vehicle)
        public MC(string registrationNumber) : base(registrationNumber) { }
    }
}
