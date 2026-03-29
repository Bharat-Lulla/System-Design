using ParkingLot.Pricing;
using ParkingLot.Payments;
using ParkingLot.Entity;
using ParkingLot.Enums;
using ParkingLot.LookupStrategy;
using ParkingLot.ParkingLotSystem;
using ParkingLot.SpotManagers;
namespace ParkingLot.Entity
{
    public class ParkingSpot
    {
        public string SpotId {get;}
        public bool IsFree {get; private set;} = true;

        public ParkingSpot(string spotId)
        {
            SpotId = spotId;
        }

        public void OccupySpot()
        {
            IsFree = false;
        }

        public void ReleaseSpot()
        {
            IsFree = true;
        }
    }
}