using System.Buffers;
using System.Dynamic;
using System.Xml.Serialization;
using ParkingLot.Pricing;
using ParkingLot.Payments;
using ParkingLot.Entity;
using ParkingLot.Enums;
using ParkingLot.LookupStrategy;
using ParkingLot.ParkingLotSystem;
using ParkingLot.SpotManagers;

namespace ParkingLot.ParkingLotSystem
{
    public class ParkingLevel
    {
        public int LevelNumber {get;}
        private readonly Dictionary<VehicleType, ParkingSpotManager> _managers;

        public ParkingLevel(int levelNumber, Dictionary<VehicleType, ParkingSpotManager> managers)
        {
            LevelNumber = levelNumber;
            _managers = managers;
        }

        public bool HasAvailability(VehicleType type)
        {
            if(_managers.TryGetValue(type, out var manager)){
                    return manager.HasFreeSpot();
            }
            return false;
        }

        public ParkingSpot? Park(VehicleType type)
        {
            if(!_managers.TryGetValue(type, out var manager))
            {
                throw new ArgumentException("Parking spot manager is not available for this type: "+ type);
            }
            return manager.Park();
        }

        public void UnPark(VehicleType type, ParkingSpot spot)
        {
            if(_managers.TryGetValue(type, out var managers))
            {
                managers.UnPark(spot);
            }
        }
    }
}