using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Fuel : PowerSource
    {
        private float m_CurrentFuelAmount;
        private float m_MaxFuelAmount;
        private eFuelType m_FuelType;

        public float CurrentFuelAmount
        {
            get { return m_CurrentFuelAmount; }
            set { m_CurrentFuelAmount = value; }
        }

        public float MaxFuelAmount
        {
            get { return m_MaxFuelAmount; }
            set { m_MaxFuelAmount = value; }
        }

        public enum eFuelType
        {
            Octan98 = 1,
            Octan96,
            Octan95,
            Soler
        }

        public struct FuelTankSize
        {
            public const int Car = 50;
            public const float Motorcycle = 5.5f;
            public const int Truck = 105;
        }

        public eFuelType FuelType
        {
            get { return m_FuelType; }
            set { m_FuelType = value; }
        }

        public static void Refule(string i_LicenseNumber, eFuelType i_FuelType, float i_AmountToRefule)
        {
            foreach (Vehicle vehicle in Vehicle.r_VehiclesList)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    if ((vehicle.PowerSource as Fuel).FuelType == i_FuelType)
                    {
                        vehicle.PowerSource.CurrentPowerSourceAmount += i_AmountToRefule;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }

            }
        }
    }
}
