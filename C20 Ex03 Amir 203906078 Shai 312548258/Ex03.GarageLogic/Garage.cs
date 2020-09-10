using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        

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



        
    }
}
