using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("Please choose the type of the vehicle : 1.Car " + Environment.NewLine + "2.Motorcycle" + Environment.NewLine + "3.Truck");
            string typeOfVehicle = Console.ReadLine();
            if (typeOfVehicle >= 1 && typeOfVehicle <= 3)
            {
                //check if license number exists in garage
                Console.WriteLine("Please enter 5 digits license plate number");
                string licensePlateNumber = Console.ReadLine();


                Console.WriteLine("Please enter license plate number");
                string licensePlateNumber = Console.ReadLine();

                Console.WriteLine("Please enter license plate number");
                string licensePlateNumber = Console.ReadLine();
            }

            


        }
        public static void Main()
        {

        }
    }
}
