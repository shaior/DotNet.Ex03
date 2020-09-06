using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Fuel:PowerSource
    {
        private float m_CurrentFuelAmount;
        private float m_MaxFuelAmount;
        private eFuelType m_FuelType;

        public float CurrentFuelAmount
        {
            get
            {
                return m_CurrentFuelAmount;
            }
            set
            {
                m_CurrentFuelAmount = value;
            }
        }

        public float MaxFuelAmount  
        {
            get
            {
                return m_MaxFuelAmount;
            }
            set
            {
                m_MaxFuelAmount = value;
            }
        }

        public enum eFuelType
        {
            Octan98 = 0,
            Octan96,
            Octan95,
            Soler
        }
        public struct FuelTankSize
        {
            public const int car = 50;
            public const double Motorcycle = 5.5;
            public const int Truck = 105;
        }

        public eFuelType FuelType 
        {
            get
            {
                return m_FuelType;
            }
            set
            {
                m_FuelType = value;
            }
        }

        public static void Refule(float i_AmountOfFuelToAdd , eFuelType i_FuelType)
        {
            if (i_FuelType == )
            {
                
            }
        }
        
    }
}
