using ParkingLot.Pricing;
using ParkingLot.Payments;
using ParkingLot.Entity;
using ParkingLot.Enums;
using ParkingLot.LookupStrategy;
using ParkingLot.ParkingLotSystem;
using ParkingLot.SpotManagers;

namespace ParkingLot.Payments
{
    public class CashPayment : Payment
    {
        public bool Pay(double amount)
        {
            Console.WriteLine($"Payment Done by Cash: {amount}");
            return true;
        }
    }
}