﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        /// <summary>
        /// checks if vehicle exists in the garage
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <returns>true if it is, false if not.</returns>
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
        
    }
}
