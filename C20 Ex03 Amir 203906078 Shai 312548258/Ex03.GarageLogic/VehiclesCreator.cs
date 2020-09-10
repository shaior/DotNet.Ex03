using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehiclesCreator
    {
        private static Vehicle m_Vehicle = null;
        //Car car1 = new Car("Mazda 3","6312523",70, PowerSource.ePowerSupply.Fuel,"michelin");

        public static Vehicle CreateVehicle(Vehicle.eVehicleType i_VehicleType, string i_ModelName, string i_LicenseNumber, float i_RemainingPowerSupply, PowerSource.ePowerSupply i_PowerSupply, string i_TiresManufacturerName)
        {
            
            switch (i_VehicleType)
            {
                
                case Vehicle.eVehicleType.Car:
                    m_Vehicle = CreateCar(i_ModelName, i_LicenseNumber, i_RemainingPowerSupply, i_PowerSupply, i_TiresManufacturerName);
                    break;
                case Vehicle.eVehicleType.Motorcycle:
                    m_Vehicle = CreateMotorcycle(i_ModelName, i_LicenseNumber, i_RemainingPowerSupply, i_PowerSupply, i_TiresManufacturerName);
                    break;
                case Vehicle.eVehicleType.Truck:
                    m_Vehicle = CreateTruck(i_ModelName, i_LicenseNumber, i_RemainingPowerSupply, i_PowerSupply,
                        i_TiresManufacturerName);
                    break;
                
            }

            return m_Vehicle;
        }

        public static Vehicle CreateCar(string i_ModelName, string i_LicenseNumber, float i_RemainingPowerSupply,
            PowerSource.ePowerSupply i_PowerSupply, string i_ManufacturerName)
        {
         
            Car car = new Car( i_ModelName, i_LicenseNumber, i_RemainingPowerSupply, i_PowerSupply, i_ManufacturerName);


            return car;
        }
        public static Vehicle CreateMotorcycle(string i_ModelName, string i_LicenseNumber, float i_RemainingPowerSupply,
            PowerSource.ePowerSupply i_PowerSupply, string i_ManufacturerName)
        {

            Motorcycle motorcycle = new Motorcycle(i_ModelName, i_LicenseNumber, i_RemainingPowerSupply, i_PowerSupply, i_ManufacturerName);


            return motorcycle;
        }
        public static Vehicle CreateTruck(string i_ModelName, string i_LicenseNumber, float i_RemainingPowerSupply,
            PowerSource.ePowerSupply i_PowerSupply, string i_ManufacturerName)
        {

            Truck truck = new Truck(i_ModelName, i_LicenseNumber, i_RemainingPowerSupply, i_PowerSupply, i_ManufacturerName);


            return truck;
        }


    }

}
