using ParkingLot.Pricing;
using ParkingLot.Payments;
using ParkingLot.Entity;
using ParkingLot.Enums;
using ParkingLot.LookupStrategy;
using ParkingLot.ParkingLotSystem;
using ParkingLot.SpotManagers;

namespace ParkingLot.ParkingLotSystem
{
    public class EntranceGate
    {
        public Ticket Enter(ParkingBuilding building, Vehicle vehicle)
        {
            return building.Allocate(vehicle);
        }
    }
}