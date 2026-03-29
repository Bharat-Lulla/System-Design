using ParkingLot.Pricing;
using ParkingLot.Payments;
using ParkingLot.Entity;
using ParkingLot.Enums;
using ParkingLot.LookupStrategy;
using ParkingLot.ParkingLotSystem;
using ParkingLot.SpotManagers;

namespace ParkingLot.SpotManagers
{
    public class FourWheelerParkingSpotManager : ParkingSpotManager
    {
        public FourWheelerParkingSpotManager(List<ParkingSpot> spots, IParkingSpotLookupStrategy strategy) : base(spots, strategy)
        {
            //Body is empty base is used to call parent class constructor
        }
    }
}