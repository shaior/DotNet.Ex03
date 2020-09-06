using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car:Vehicle
    {
        private eCarColor m_Color;
        private eNumberOfDoors m_DoorsNumber;
        private const float K_MaxBatteryLifeTime = 4.8f;

        public Car(string i_ModelName, string i_LicenseNumber,float i_RemainingPowerSupply) 
            :base(i_ModelName, i_LicenseNumber, i_RemainingPowerSupply)

        {
            List<Wheel> carWheels = new List<Wheel>(4);
            carWheels.Add();
        }

        public enum eCarColor
        {
            Grey,
            White,
            Green,
            Red
        }
        public enum eNumberOfDoors
        {
            Two,
            Three,
            Four,
            Five
        }

        public override void AssignEnergySourceToVehicle()
        {
            if (PowerSource is Battery)
            {
                PowerSource.MaxPowerSourceAmount = K_MaxBatteryLifeTime;
            }
            else
            {
                ((Fuel)PowerSource).FuelType = Fuel.eFuelType.Octan96;
                PowerSource.MaxPowerSourceAmount = Fuel.FuelTankSize.car;
            }
        }
    }
}
