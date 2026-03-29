using ParkingLot.Pricing;
using ParkingLot.Payments;
using ParkingLot.Entity;
using ParkingLot.Enums;
using ParkingLot.LookupStrategy;
using ParkingLot.ParkingLotSystem;
using ParkingLot.SpotManagers;

namespace ParkingLot.Entity
{
    public class Vehicle
    {
        public string VehicleNumber {get;}
        public VehicleType VehicleType {get;}

        public Vehicle(string vehicleNumber, VehicleType vehicleType)
        {
            VehicleNumber = vehicleNumber;
            VehicleType = vehicleType;
        }
    }
    
}