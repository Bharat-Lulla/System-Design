using ParkingLot.Pricing;
using ParkingLot.Payments;
using ParkingLot.Entity;
using ParkingLot.Enums;
using ParkingLot.LookupStrategy;
using ParkingLot.ParkingLotSystem;
using ParkingLot.SpotManagers;

namespace ParkingLot.ParkingLotSystem
{
    public class ExitGate
    {
        private readonly CostComputation _costComputation;

        public ExitGate(CostComputation costComputation)
        {
            _costComputation = costComputation;
        }

        public void CompleteExit(ParkingBuilding building, Ticket ticket, Payment payment)
        {
            double amount = CalculatePrice(ticket);

            bool success = payment.Pay(amount);

            if (!success)
            {
                throw new InvalidOperationException("Payment unsuccesfull, Exit denied");
            }

            building.Release(ticket);
            Console.WriteLine("Exit Completed");
        }

        private double CalculatePrice(Ticket ticket)
        {
            return _costComputation.Compute(ticket);
        }
    }
}