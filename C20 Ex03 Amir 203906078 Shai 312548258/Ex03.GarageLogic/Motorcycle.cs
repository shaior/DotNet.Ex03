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

        public Motorcycle(string i_ModelName, string i_LicenseNumber, float i_RemainingPowerSupply,
            PowerSource.ePowerSupply i_PowerSupply, string i_ManufacturerName)
            : base(i_ModelName, i_LicenseNumber, i_RemainingPowerSupply, i_PowerSupply)
        {
            
        }

       
        public enum eLicenseType
        {
            B2,
            B1,
            A1,
            A
        }
    }
}
