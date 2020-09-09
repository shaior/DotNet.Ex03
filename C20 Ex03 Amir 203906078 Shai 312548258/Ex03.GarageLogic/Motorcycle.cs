using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle:Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;
        private const float K_MaxBatteryLifeTime = 1.6f;
        private const int k_NumberOfWheels = 2;
        private const float k_MinEngineVolume = 1f;
        private const float k_MaxEngineVolume = 2000f;


        public Motorcycle(string i_ModelName, string i_LicenseNumber, float i_RemainingPowerSupply,
            PowerSource.ePowerSupply i_PowerSupply, string i_ManufacturerName)
            : base(i_ModelName, i_LicenseNumber, i_RemainingPowerSupply, i_PowerSupply)
        {
            
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
            set
            {
                if (value < k_MinEngineVolume || value > k_MaxEngineVolume)
                {
                    throw new ValueOutOfRangeException(k_MinEngineVolume,k_MaxEngineVolume);
                }
                else
                {
                    m_EngineVolume = value;
                }
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }

      

        public override void AssignEnergySourceToVehicle()
        {
            if (PowerSource is Battery)
            {
                PowerSource.MaxPowerSourceAmount = K_MaxBatteryLifeTime;
            }
            else
            {
                ((Fuel)PowerSource).FuelType = Fuel.eFuelType.Octan95;
                PowerSource.MaxPowerSourceAmount = Fuel.FuelTankSize.Motorcycle;
            }
        }

        public enum eLicenseType
        {
            B2 = 0,
            B1,
            A1,
            A
        }
    }
}
