using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class UserInputValidation
    {
        public static bool LicensePlateValidation(string i_LicensePlate)
        {
            bool checkLicensePlate = true;

            if (i_LicensePlate.Length != 5)
            {
                Console.WriteLine("This License plate number is not valid");
                checkLicensePlate = false;
            }
            else
            {
                checkLicensePlate = true;
            }
            return checkLicensePlate;
        }

        
    }
}
