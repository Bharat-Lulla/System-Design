using ParkingLot.Pricing;
using ParkingLot.Payments;
using ParkingLot.Entity;
using ParkingLot.Enums;
using ParkingLot.LookupStrategy;
using ParkingLot.ParkingLotSystem;
using ParkingLot.SpotManagers;

namespace ParkingLot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IParkingSpotLookupStrategy strategy = new RandomLookupStrategy();

            var levelOneManagers = new Dictionary<VehicleType, ParkingSpotManager>
            {
                {
                    VehicleType.TwoWheeler,
                    new TwoWheelerParkingSpotManager(new List<ParkingSpot>
                    {
                        new ParkingSpot("L1-S1"),
                        new ParkingSpot("L1-S2")
                    }, strategy)
                },
                {
                    VehicleType.FourWheeler,
                    new FourWheelerParkingSpotManager(new List<ParkingSpot>
                    {
                        new ParkingSpot("L1-S3")
                    }, strategy)
                }
            };

            ParkingLevel level1 = new ParkingLevel(1, levelOneManagers);

            var levelTwoManagers = new Dictionary<VehicleType, ParkingSpotManager>
            {
                {
                    VehicleType.TwoWheeler,
                    new TwoWheelerParkingSpotManager(new List<ParkingSpot>
                    {
                        new ParkingSpot("L2-S1")
                    }, strategy)
                },
                {
                    VehicleType.FourWheeler,
                    new FourWheelerParkingSpotManager(new List<ParkingSpot>
                    {
                        new ParkingSpot("L2-S2"),
                        new ParkingSpot("L2-S3")
                    }, strategy)
                }
            };

            ParkingLevel level2 = new ParkingLevel(2, levelTwoManagers);

            ParkingBuilding building = new ParkingBuilding(new List<ParkingLevel> {level1, level2});

            ParkingLotSystem.ParkingLot parkingLot = new ParkingLotSystem.ParkingLot(building, new EntranceGate(), new ExitGate(new CostComputation(new FixedCostPricing())));

            Vehicle bike = new Vehicle("Bike-101", VehicleType.TwoWheeler);
            Vehicle car = new Vehicle("Car-101", VehicleType.FourWheeler);

            Ticket t1 = parkingLot.VehicleArrives(bike);
            Ticket t2 = parkingLot.VehicleArrives(car);

            parkingLot.VehicleExits(t1, new CashPayment());

            parkingLot.VehicleExits(t2, new UPIPayment());
        }
    }
    
}