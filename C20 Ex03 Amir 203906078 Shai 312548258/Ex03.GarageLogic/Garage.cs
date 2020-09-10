using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Vehicle m_Vehicle;
        private string m_OwnerPhoneNumber;
        private string m_OwnerName;

        public Garage(Vehicle i_newVehicle, string i_OwnerPhoneNumber, string i_OwnerName)
        {
            this.m_Vehicle = i_newVehicle;
            this.m_OwnerName = i_OwnerName;
            this.m_OwnerPhoneNumber = i_OwnerPhoneNumber;
        }
        
        public void InsertVehicleToGarage(Garage i)
        {
            List<Garage> m_GarageInfo
        }

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
