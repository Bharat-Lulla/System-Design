using ParkingLot.Pricing;
using ParkingLot.Payments;
using ParkingLot.Entity;
using ParkingLot.Enums;
using ParkingLot.LookupStrategy;
using ParkingLot.ParkingLotSystem;
using ParkingLot.SpotManagers;

namespace ParkingLot.ParkingLotSystem
{
    public class ParkingLot
    {
        private readonly ParkingBuilding _building;
        private readonly EntranceGate _entranceGate;
        private readonly ExitGate _exitGate;

        public ParkingLot(ParkingBuilding building, EntranceGate entranceGate, ExitGate exitGate)
        {
            _building = building;
            _entranceGate = entranceGate;
            _exitGate = exitGate;
        }

        public Ticket VehicleArrives(Vehicle vehicle)
        {
            return _entranceGate.Enter(_building, vehicle);
        }

        public void VehicleExits(Ticket ticket, Payment payment)
        {
            _exitGate.CompleteExit(_building, ticket, payment);
        }
    }
}