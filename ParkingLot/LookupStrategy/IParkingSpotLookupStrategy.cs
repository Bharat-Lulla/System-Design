using ParkingLot.Pricing;
using ParkingLot.Payments;
using ParkingLot.Entity;
using ParkingLot.Enums;
using ParkingLot.LookupStrategy;
using ParkingLot.ParkingLotSystem;
using ParkingLot.SpotManagers;

namespace ParkingLot.LookupStrategy
{
    public interface IParkingSpotLookupStrategy
    {
        ParkingSpot? SelectSpot(List<ParkingSpot> spots);
    }
}