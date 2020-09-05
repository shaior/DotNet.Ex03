using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Fuel
    {
        private float m_CurrentFuelAmount;
        private float m_MaxFuelAmount;

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
            Octan98,
            Octan96,
            Octan95,
            Soler
        }

        public static void Refule(float i_AmountOfFuelToAdd , eFuelType i_FuelType)
        {

        }
        
    }
}
