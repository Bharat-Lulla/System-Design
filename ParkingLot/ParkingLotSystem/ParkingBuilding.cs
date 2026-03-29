using System.Diagnostics.Tracing;
using ParkingLot.Pricing;
using ParkingLot.Payments;
using ParkingLot.Entity;
using ParkingLot.Enums;
using ParkingLot.LookupStrategy;
using ParkingLot.ParkingLotSystem;
using ParkingLot.SpotManagers;

namespace ParkingLot.ParkingLotSystem
{
    public class ParkingBuilding
    {
        private readonly List<ParkingLevel> _levels;

        public ParkingBuilding(List<ParkingLevel> levels)
        {
            _levels = levels;
        }

        public Ticket Allocate(Vehicle vehicle)
        {
            foreach(var level in _levels)
            {
                if (level.HasAvailability(vehicle.VehicleType))
                {
                    ParkingSpot? spot = level.Park(vehicle.VehicleType);

                    if(spot != null)
                    {
                        Ticket ticket = new Ticket(vehicle, level, spot);
                        Console.WriteLine($"Parking allocated at level: {level.LevelNumber} spot: {spot.SpotId}");
                        return ticket;
                    }
                }
            }
            throw new InvalidOperationException("Parking Full");
        }

        public void Release(Ticket ticket)
        {
            ticket.Level.UnPark(ticket.Vehicle.VehicleType, ticket.Spot);
        }
    }
}