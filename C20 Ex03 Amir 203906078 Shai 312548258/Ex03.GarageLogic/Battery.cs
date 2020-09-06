using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Battery:PowerSource
    {
        private float m_BatteryTimeLeft;
        private float m_MaxBatteryLife;

        public float BatteryTimeLeft
        {
            get
            {
                return m_BatteryTimeLeft;
            }
            set
            {
                m_BatteryTimeLeft = value;
            }
        }

        public float MaxBatteryLife
        {
            get
            {
                return m_MaxBatteryLife;
            }
        }


    }
}
