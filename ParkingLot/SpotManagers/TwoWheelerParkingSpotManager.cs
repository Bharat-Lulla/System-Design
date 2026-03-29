using ParkingLot.Pricing;
using ParkingLot.Payments;
using ParkingLot.Entity;
using ParkingLot.Enums;
using ParkingLot.LookupStrategy;
using ParkingLot.ParkingLotSystem;
using ParkingLot.SpotManagers;

namespace ParkingLot.SpotManagers
{
    public class TwoWheelerParkingSpotManager : ParkingSpotManager
    {
        public TwoWheelerParkingSpotManager(List<ParkingSpot> spots, IParkingSpotLookupStrategy strategy) : base(spots, strategy)
        {
            //this body is left intertionally because we are using base to cal the parent class
        }
    }
}