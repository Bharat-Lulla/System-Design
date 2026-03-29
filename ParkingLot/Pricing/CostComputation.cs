using ParkingLot.Pricing;
using ParkingLot.Payments;
using ParkingLot.Entity;
using ParkingLot.Enums;
using ParkingLot.LookupStrategy;
using ParkingLot.ParkingLotSystem;
using ParkingLot.SpotManagers;

namespace ParkingLot.Pricing
{
    public class CostComputation
    {
        private readonly PricingStrategy _strategy;

        public CostComputation(PricingStrategy strategy)
        {
            _strategy = strategy;
        }

        public double Compute(Ticket ticket)
        {
            return _strategy.Calculate(ticket);
        }
    }
}