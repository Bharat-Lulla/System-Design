using ParkingLot.Pricing;
using ParkingLot.Payments;
using ParkingLot.Entity;
using ParkingLot.Enums;
using ParkingLot.LookupStrategy;
using ParkingLot.ParkingLotSystem;
using ParkingLot.SpotManagers;

namespace ParkingLot.Payments
{
    public class UPIPayment : Payment
    {
        public bool Pay(double amount)
        {
            Console.WriteLine($"Paid via UPI: {amount}");
            return true;
        }
    }
}