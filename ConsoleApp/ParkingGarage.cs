using ConsoleApp.Models;
using System.Text.Json;
using System.IO;  // Import for file handling
using System.Linq;  // Import for LINQ methods
using System.Collections.Generic;  // Import for List<T>

namespace ConsoleApp
{
    public class ParkingGarage
    {
        private List<ParkingSpot> parkingSpots;
        private readonly string dataFilePath = "parkingData.json";
        private readonly int freeMinutes = 10;

        public ParkingGarage()
        {
            parkingSpots = new List<ParkingSpot>();
            LoadData();
        }

        private void LoadData()
        {
            if (File.Exists(dataFilePath))
            {
                var jsonData = File.ReadAllText(dataFilePath);
                parkingSpots = JsonSerializer.Deserialize<List<ParkingSpot>>(jsonData) ?? new List<ParkingSpot>();
            }
            else
            {
                // Adding 100 parking spots with size 1
                for (int i = 0; i < 100; i++)
                {
                    parkingSpots.Add(new ParkingSpot(1));  // Initialize with default size
                }
            }
        }

        private void SaveData()
        {
            var jsonData = JsonSerializer.Serialize(parkingSpots, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(dataFilePath, jsonData);
        }

        public void ParkVehicle(Vehicle vehicle)
        {
            var spot = parkingSpots.FirstOrDefault(s => !s.IsFull);  // Find the first available spot
            if (spot != null)
            {
                spot.ParkVehicle(vehicle);
                SaveData();
                Console.WriteLine($"{vehicle.GetType().Name} parked with registration number {vehicle.RegistrationNumber}.");
            }
            else
            {
                Console.WriteLine("No available spots.");
            }
        }

        public void RemoveVehicle(string regNumber)
        {
            foreach (var spot in parkingSpots)
            {
                var vehicle = spot.Vehicles.FirstOrDefault(v => v.RegistrationNumber == regNumber);
                if (vehicle != null)
                {
                    var duration = vehicle.GetParkingDuration();
                    var fee = duration.TotalMinutes <= freeMinutes ? 0 : vehicle.HourlyRate * Math.Ceiling(duration.TotalMinutes / 60);
                    spot.RemoveVehicle(vehicle);
                    SaveData();
                    Console.WriteLine($"Vehicle {regNumber} removed. Fee: {fee} CZK.");
                    return;
                }
            }
            Console.WriteLine("Vehicle not found.");
        }
    }
}
