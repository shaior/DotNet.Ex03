using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car:Vehicle
    {
        private eCarColor m_Color;
        private eNumberOfDoors m_DoorsNumber;
        private const float K_MaxBatteryLifeTime = 4.8f;
        private const int k_NumberOfWheels = 4;
        public Car(string i_ModelName, string i_LicenseNumber,float i_RemainingPowerSupply, PowerSource.ePowerSupply i_PowerSupply,string i_ManufacturerName) 
            :base(i_ModelName, i_LicenseNumber, i_RemainingPowerSupply, i_PowerSupply)
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheels.Add(new Wheel(i_ManufacturerName, (float)Wheel.eMaxTierAirPressure.Car));
            }
        }

        public override string ToString()
        {
            
            return string.Format(@"{0},Car's Color: {1}, Car's doors number: {2}, ",(this as Vehicle).GetVehicleDeatils(), m_Color.ToString(), m_DoorsNumber.ToString());
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_DoorsNumber;
            }
            set
            {
                m_DoorsNumber = value;
            }
        }

        public eCarColor CarColor
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }
        public enum eCarColor
        {
            Grey = 1,
            White,
            Green,
            Red
        }
        public enum eNumberOfDoors
        {
            Two = 2,
            Three,
            Four,
            Five
        }

        /// <summary>
        /// this method assign the vehicle energy source
        /// </summary>
        public override void AssignEnergySourceToVehicle()
        {
            if (PowerSource is Battery)
            {
                PowerSource.MaxPowerSourceAmount = K_MaxBatteryLifeTime;
            }
            else
            {
                ((Fuel)PowerSource).FuelType = Fuel.eFuelType.Octan96;
                PowerSource.MaxPowerSourceAmount = Fuel.FuelTankSize.Car;
            }
        }
    }
}
