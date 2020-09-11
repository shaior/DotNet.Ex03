using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Battery:PowerSource
    {
        private float m_BatteryTimeLeft;
        private const float m_MaxBatteryLife = 2f;

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

        /// <summary>
        /// charging the battery
        /// </summary>
        /// <param name="i_LicenseNumber">license number</param>
        /// <param name="i_RechargeAmount">amount to recharge</param>
        public static void RechargeVehicleBattery(string i_LicenseNumber , string i_RechargeAmount)
        {
            foreach (Vehicle vehicle in Vehicle.r_VehiclesList)
            {
                if (vehicle.PowerSource is Battery)
                {
                    (vehicle.PowerSource as Battery).CurrentPowerSourceAmount += float.Parse(i_RechargeAmount);
                }
            }
        }
    }
}
