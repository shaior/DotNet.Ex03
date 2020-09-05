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

        public static void Main()
        {

        }
    }
}
