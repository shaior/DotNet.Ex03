using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class VehiclesCreator
    {
        //Car car1 = new Car("Mazda 3","6312523",70, PowerSource.ePowerSupply.Fuel,"michelin");

        public static void CreateVehicle(Vehicle.eVehicleType i_VehicleType, string i_ModelName, string i_LicenseNumber, float i_RemainingPowerSupply, PowerSource.ePowerSupply i_PowerSupply, string i_ManufacturerName)
        {
            switch (i_VehicleType)
            {
                //for car creation
                case Vehicle.eVehicleType.Car:
                    CreateCar(i_ModelName, i_LicenseNumber, i_RemainingPowerSupply, i_PowerSupply, i_ManufacturerName);
                    break;

                case Vehicle.eVehicleType.Motorcycle:
                    

                case Vehicle.eVehicleType.Truck:

                
            }
        }

        public static Vehicle CreateCar(string i_ModelName, string i_LicenseNumber, float i_RemainingPowerSupply,
            PowerSource.ePowerSupply i_PowerSupply, string i_ManufacturerName)
        {
            Car car = new Car( i_ModelName, i_LicenseNumber, i_RemainingPowerSupply, i_PowerSupply, i_ManufacturerName);
            return car;
        }

        public static bool CheckIfVehicleExistsInGarage(Vehicle i_Vehicle)
        {
            //logic
            return true;
        }
    }

}
