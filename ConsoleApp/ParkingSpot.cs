namespace ConsoleApp.Models
{
    public class ParkingSpot
    {
        public int Size { get; set; }  // Example property to define the spot size
        public bool IsFull => Vehicles.Count >= Size;  // Logic to determine if the spot is full
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        public ParkingSpot(int size)
        {
            Size = size;
        }

        public void ParkVehicle(Vehicle vehicle)
        {
            if (!IsFull)
            {
                Vehicles.Add(vehicle);  // Add vehicle to the spot
            }
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            Vehicles.Remove(vehicle);  // Remove vehicle from the spot
        }
    }
}
