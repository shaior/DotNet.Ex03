using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class PowerSource
    {
        private float m_CurrentPowerSourceAmount;
        private float m_MaxPowerSourceAmount;
        public enum ePowerSupply
        {
            Fuel = 1,
            Battery = 2
        }

        public float CurrentPowerSourceAmount
        {
            get
            {
                return m_CurrentPowerSourceAmount;
            }

            set
            {
                if (value + m_CurrentPowerSourceAmount > m_MaxPowerSourceAmount)
                {
                    throw new ValueOutOfRangeException(0,m_MaxPowerSourceAmount);
                }
                else
                {
                    m_CurrentPowerSourceAmount = value;
                }

               
            }
        }

        public float MaxPowerSourceAmount
        {
            get
            {
                return m_MaxPowerSourceAmount;
            }

            set
            {
                m_MaxPowerSourceAmount = value;
            }
        }

        public static ePowerSupply getPowerSupplyType(string i_PowerSupplyInput)
        {
            ePowerSupply powerSupply = ePowerSupply.Fuel;
            if (int.Parse(i_PowerSupplyInput) == 1)
            {
                powerSupply = ePowerSupply.Fuel;
            }
            else
            {
                powerSupply = ePowerSupply.Battery;
            }

            return powerSupply;
        }
    }
}
