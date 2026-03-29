using ParkingLot.Pricing;
using ParkingLot.Payments;
using ParkingLot.Entity;
using ParkingLot.Enums;
using ParkingLot.LookupStrategy;
using ParkingLot.ParkingLotSystem;
using ParkingLot.SpotManagers;

namespace ParkingLot.LookupStrategy
{
    public class RandomLookupStrategy : IParkingSpotLookupStrategy
    {
        public ParkingSpot? SelectSpot(List<ParkingSpot> spots)
        {
            foreach(var spot in spots)
            {
                if (spot.IsFree) return spot;
            }
            return null;
        }
    }
}