using ParkingLot.Pricing;
using ParkingLot.Payments;
using ParkingLot.Entity;
using ParkingLot.Enums;
using ParkingLot.LookupStrategy;
using ParkingLot.ParkingLotSystem;
using ParkingLot.SpotManagers;

namespace ParkingLot.SpotManagers
{
    public abstract class ParkingSpotManager
    {
        protected readonly List<ParkingSpot> _spots;
        protected readonly IParkingSpotLookupStrategy _strategy;

        private readonly object _lockObject = new object();

        protected ParkingSpotManager(List<ParkingSpot> spots, IParkingSpotLookupStrategy strategy)
        {
            _spots = spots;
            _strategy = strategy;
        }   

        public ParkingSpot? Park()
        {
            lock (_lockObject)
            {
                ParkingSpot? spot = _strategy.SelectSpot(_spots);

                if(spot == null) return null;

                spot.OccupySpot();
                return spot;
            }
        }

        public void UnPark(ParkingSpot spot)
        {
            lock (_lockObject)
            {
                spot.ReleaseSpot();
            }
        }

        public bool HasFreeSpot()
        {
            lock (_lockObject)
            {
                 return _spots.Any(spot => spot.IsFree);
            }
        }

    }
}