using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Motorcycle:Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;
        

       
        public enum eLicenseType
        {
            B2,
            B1,
            A1,
            A
        }
    }
}
