using ParkingLot.Pricing;
using ParkingLot.Payments;
using ParkingLot.Entity;
using ParkingLot.Enums;
using ParkingLot.LookupStrategy;
using ParkingLot.ParkingLotSystem;
using ParkingLot.SpotManagers;

namespace ParkingLot.Pricing
{
    public class FixedCostPricing : PricingStrategy
    {
        public double Calculate(Ticket ticket)
        {
            return 100;
        }
    }
}