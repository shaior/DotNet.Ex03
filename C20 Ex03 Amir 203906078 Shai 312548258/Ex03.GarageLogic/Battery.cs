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

        public static void Recharge(string i_LicenseNumber,float i_NumberOfMinutesToRecharge)
        {
            bool isVehicleFound = false;
            foreach (Vehicle vehicle in Vehicle.r_VehiclesList)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    (vehicle.PowerSource as Battery).BatteryTimeLeft += i_NumberOfMinutesToRecharge;
                    isVehicleFound = true;
                }

            }

            if (!isVehicleFound)
            {
                throw new ArgumentException();
            }
        }

    }
}
