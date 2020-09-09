using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        protected internal string m_Manufacturer;
        protected internal float m_CurrentTierPressure;
        protected internal readonly float r_MaxTierPressure;

        public Wheel(string i_ManufacturerName, float i_MaxTierPressure)
        {
            this.m_CurrentTierPressure = i_MaxTierPressure;
            this.r_MaxTierPressure = i_MaxTierPressure;
            this.m_Manufacturer = i_ManufacturerName;
        
        }

        public string Manufacturer
        {
            get
            {
                return m_Manufacturer;
            } 
            set
            {
                m_Manufacturer = value;

            }
        }

        public float CurrentTierPressure
        {
            get
            {
                return m_CurrentTierPressure;
            }
        }

        public float MaxTierPressure
        {
            get
            {
                return r_MaxTierPressure;
            }
        }

        public void AddTierPressure(float i_TierPressureToAdd)
        {
            if (i_TierPressureToAdd <= 0 || m_CurrentTierPressure + i_TierPressureToAdd > r_MaxTierPressure)
            {
                // MaxValue is the max air pressure - current air pressure
                throw new ValueOutOfRangeException(0, r_MaxTierPressure - m_CurrentTierPressure);
            }
            else
            {
                m_CurrentTierPressure += i_TierPressureToAdd;
            }
        }


        public enum eMaxTierAirPressure
        {
            Car = 32,
            Motorcycle = 28,
            Truck = 30
        }
    }
}
