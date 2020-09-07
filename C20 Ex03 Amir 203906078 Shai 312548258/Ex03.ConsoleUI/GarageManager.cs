using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageManager
    {
        public static void GarageMenu()
        {
            string choice;
            Console.WriteLine("Welcome To A&S Garage Manager! Type (1-7) to select from Below: ");
            choice = Console.ReadLine();
            

            switch (choice)
            {
                case "1":
                    Console.WriteLine("hi");
                    break;
                    

            }
        }

        public static void CreateNewVehicle()
        {
            string typeOfVehicle = string.Empty;
            try
            {
                Console.WriteLine("Please choose the type of the vehicle : 1.Car " + Environment.NewLine +
                                  "2.Motorcycle" + Environment.NewLine + "3.Truck");
                typeOfVehicle = Console.ReadLine();
                if (int.Parse(typeOfVehicle) >= 1 && int.Parse(typeOfVehicle) <= 3)
                {
                    bool checkPlateNumber = true;
                    while (checkPlateNumber)
                    {
                        //check if license number exists in garage
                        Console.WriteLine("Please enter 5 digits license plate number");
                        string licensePlateNumber = Console.ReadLine();
                        checkPlateNumber = UserInputValidation.LicensePlateValidation(licensePlateNumber);
                        if (!checkPlateNumber)
                        {
                            continue;
                        }
                    }


                    Console.WriteLine("Please enter license plate number");
                    //string licensePlateNumber = Console.ReadLine();

                    Console.WriteLine("Please enter license plate number");
                    //string licensePlateNumber = Console.ReadLine();
                }
            }

            catch (Exception ex)
            {
                string exceptionType = string.Format("input is not valid - {0}", ex.Message);
                Console.WriteLine(exceptionType);
            }

        }

        public void AddVehicleDetails(Vehicle i_Vehicle)
        {
           

            if (i_Vehicle is Car)
            {

                //AddColor
                //AddDoors
            }
            else if (i_Vehicle is Motorcycle)
            {
                //AddEngineCapacity
                //AddLicenseType
            }

            if (i_Vehicle is Truck)
            {
                //AddDangerousGoods
                //AddCargoVolume
            }
            else
            {
                if (i_Vehicle.PowerSource is Battery)
                {
                    //getBatteryTimeLeft
                    //getMaxBatteryLife
                    //chargeBATTERY - FLOAT
                }
                else if (i_Vehicle.PowerSource is Fuel)
                {
                    //getFuelType
                    //getAmountOfFUelREMAINING
                    //getMaxFueltankCapacity
                    //refule
                }
            }

            //AddAirPressureToWheels
        }

        public static void Main()
        {
            Vehicle v,c;
            v = GarageLogic.VehiclesCreator.CreateVehicle(Vehicle.eVehicleType.Car, "Mazda",
                "34545", 50, PowerSource.ePowerSupply.Fuel, "goodyear");
           

            c = GarageLogic.VehiclesCreator.CreateVehicle(Vehicle.eVehicleType.Car, "Toyota",
                "33333", 60, PowerSource.ePowerSupply.Battery, "goodyear");

            Console.WriteLine(v);
        }
    }
}
