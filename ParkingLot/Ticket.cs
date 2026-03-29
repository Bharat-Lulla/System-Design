using ParkingLot.Pricing;
using ParkingLot.Payments;
using ParkingLot.Entity;
using ParkingLot.Enums;
using ParkingLot.LookupStrategy;
using ParkingLot.ParkingLotSystem;
using ParkingLot.SpotManagers;

namespace ParkingLot
{
    public class Ticket
    {
        public Vehicle Vehicle {get;}
        public ParkingLevel Level {get;}
        public ParkingSpot Spot {get;}

        public DateTime EntryTime {get;}

        public Ticket(Vehicle vehicle, ParkingLevel level, ParkingSpot spot)
        {
            Vehicle = vehicle;
            Level = level;
            Spot = spot;
            EntryTime = DateTime.Now;
        }
    }
}