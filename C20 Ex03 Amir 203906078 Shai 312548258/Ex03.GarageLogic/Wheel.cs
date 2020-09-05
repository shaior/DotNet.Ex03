using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private string m_Manufacturer;
        private float m_TierPressure;
        private float m_MaxTierPressure;

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


        public float TierPressure
        {
            get
            {
                return m_TierPressure;
            }
            set
            {
                m_TierPressure = value;

            }
        }

        public float MaxTierPressure
        {
            get
            {
                return m_MaxTierPressure;
            }
            set
            {
                m_MaxTierPressure = value;  
            }

        }
        public static void AddTierPressure(float i_TierPressureToAdd)
        {
            
        }

        public enum eMaxTierAirPressure
        {
            Car = 32,
            Motorcycle = 28,
            Truck = 30
        }
    }
}
