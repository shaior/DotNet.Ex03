using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private string m_OwnerName;
        private string m_OwnerNumber;
        

        private static Dictionary<string, eCurrentVehicleState> m_CurrentGarageVehicles = new Dictionary<string, eCurrentVehicleState>();
        
        public static Dictionary<string,eCurrentVehicleState> VehiclesState
        {
            get
            {
                return m_CurrentGarageVehicles;
            }
            set
            {
                m_CurrentGarageVehicles = value;
            }
        }
        public static bool CheckIfVehicleExistsInGarage(string i_LicenseNumber)
        {
            bool isLicenseNumberExists = false;
            foreach (Vehicle vehicle in Vehicle.r_VehiclesList)
            {
                if (i_LicenseNumber == vehicle.LicenseNumber)
                {
                    isLicenseNumberExists = true;
                }
            }

            return isLicenseNumberExists;
        }
        
        //methods
        //methd changeVehicleState
        //addvehicletoTreatment
        //checkIfVehicleExist

        public enum eCurrentVehicleState
        {
            CurrentlyRepairing = 0,
            Repaired,
            PaidUp
        }
    }
}
