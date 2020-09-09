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

               AddCarColor(i_Vehicle);
               AddCarDoors(i_Vehicle);
            }
            else if (i_Vehicle is Motorcycle)
            {
                AddMotorcycleEngineVolume(i_Vehicle);
                AddMotorcycleLicenseType(i_Vehicle);
            }

            if (i_Vehicle is Truck)
            {
                IsCarryingDangerousGoods(i_Vehicle);
                AddCargoVolume(i_Vehicle);
            }
            else
            {
                if (i_Vehicle.PowerSource is Battery)
                {
                    GetBatteryTimeLeft(i_Vehicle);
                    GetMaxBatteryLifeTime(i_Vehicle);
                    ChargeBattery(i_Vehicle);
                }
                else if (i_Vehicle.PowerSource is Fuel)
                {
                    GetFuelType(i_Vehicle);
                    GetAmountOfFuelRemaining(i_Vehicle);
                    GetMaxFuelTankCapacity(i_Vehicle);
                    //RefuleGasTank(i_Vehicle,)
                }
            }

            //AddAirPressureToWheels
        }

        public void AddCarColor(Vehicle i_Vehicle)
        {
            
            Console.WriteLine("Choose car Color: 1.Grey 2.White 3.Green 4.Red");
            string userColorChoice = Console.ReadLine();

            if (int.Parse(userColorChoice) < 1 || int.Parse(userColorChoice) > 4)
            {
                throw new ArgumentException();
            }
            else
            {
                switch (userColorChoice)
                {
                    case "1":
                        (i_Vehicle as Car).CarColor = Car.eCarColor.Grey;
                        break;
                    case "2":
                        (i_Vehicle as Car).CarColor = Car.eCarColor.White;
                        break;
                    case "3":
                        (i_Vehicle as Car).CarColor = Car.eCarColor.Green;
                        break;
                    case "4":
                        (i_Vehicle as Car).CarColor = Car.eCarColor.Red;
                        break;

                }
            }

        }

        public void AddCarDoors(Vehicle i_Vehicle)
        {
            Console.WriteLine("Choose Number of doors: 1.Two Doors 2.Three Doors 3.Four Doors 4.Five Doors");
            string userDoorNumberChoice = Console.ReadLine();

            if (int.Parse(userDoorNumberChoice) < 1 || int.Parse(userDoorNumberChoice) > 4)
            {
                throw new ArgumentException();
            }
            else
            {
                switch (userDoorNumberChoice)
                {
                    case "1":
                        (i_Vehicle as Car).NumberOfDoors = Car.eNumberOfDoors.Two;
                        break;
                    case "2":
                        (i_Vehicle as Car).NumberOfDoors = Car.eNumberOfDoors.Three;
                        break;
                    case "3":
                        (i_Vehicle as Car).NumberOfDoors = Car.eNumberOfDoors.Four;
                        break;
                    case "4":
                        (i_Vehicle as Car).NumberOfDoors = Car.eNumberOfDoors.Five;
                        break;

                }
            }
        }

        public void AddMotorcycleEngineVolume(Vehicle i_Vehicle)
        {
            
            int engineVolume;
            Console.WriteLine("Choose Engine Volume: ");
            string engineVolumeInput = Console.ReadLine();

            bool engineVolumeCheck = int.TryParse(engineVolumeInput, out engineVolume);
            if (!engineVolumeCheck)
            {
                throw new FormatException();
            }
            else
            {
                (i_Vehicle as Motorcycle).EngineVolume = engineVolume;
            }
        }

        public void AddMotorcycleLicenseType(Vehicle i_Vehicle)
        {
            Console.WriteLine("Choose License Type: 1.B2 2.B1 3.A1 4.A");
            string userLicenceTypeInput = Console.ReadLine();

            if (int.Parse(userLicenceTypeInput) < 1 || int.Parse(userLicenceTypeInput) > 4)
            {
                throw new ArgumentException();
            }
            else
            {
                switch (userLicenceTypeInput)
                {
                    case "1":
                        (i_Vehicle as Motorcycle).LicenseType = Motorcycle.eLicenseType.B2;
                        break;
                    case "2":
                        (i_Vehicle as Motorcycle).LicenseType = Motorcycle.eLicenseType.B1;
                        break;
                    case "3":
                        (i_Vehicle as Motorcycle).LicenseType = Motorcycle.eLicenseType.A1;
                        break;
                    case "4":
                        (i_Vehicle as Motorcycle).LicenseType = Motorcycle.eLicenseType.A;
                        break;

                }
            }
        }

        public void IsCarryingDangerousGoods(Vehicle i_Vehicle)
        {
            bool isCarryingDG;
            Console.WriteLine("Does the Truck Transport Dangerous Goods? 1.Yes 2.No");
            string isCarryingDangerousGoodsInput = Console.ReadLine();
            
            if (int.Parse(isCarryingDangerousGoodsInput) < 1 || int.Parse(isCarryingDangerousGoodsInput) > 2)
            {
                throw new ArgumentException();
            }
            else
            {
                if (int.Parse(isCarryingDangerousGoodsInput) == 1)
                {
                    isCarryingDG = true;
                }
                else
                {
                    isCarryingDG = false;
                }

                (i_Vehicle as Truck).ContainsDangerousGoods = isCarryingDG;
            }

        }

        public void AddCargoVolume(Vehicle i_Vehicle)
        {
            float cargoVolume;
            Console.WriteLine("Choose Cargo Volume: ");
            string cargoVolumeInput = Console.ReadLine();

            bool cargoVolumeCheck = float.TryParse(cargoVolumeInput, out cargoVolume);
            if (!cargoVolumeCheck)
            {
                throw new FormatException();
            }
            else
            {
                (i_Vehicle as Truck).CargoVolume = cargoVolume;

            }
        }

        public float GetBatteryTimeLeft(Vehicle i_Vehicle)
        {
            return i_Vehicle.PowerSource.CurrentPowerSourceAmount;
        }

        public float GetMaxBatteryLifeTime(Vehicle i_Vehicle)
        {
            return i_Vehicle.PowerSource.MaxPowerSourceAmount;
        }

        public void ChargeBattery(Vehicle i_Vehicle)
        {
            Console.WriteLine("How many hours do you like to add to the battery? ");
            string hoursToBatteryInput = Console.ReadLine();
            float hoursToCharge;
            bool checkHoursInput = float.TryParse(hoursToBatteryInput, out hoursToCharge);
            if (!checkHoursInput)
            {
                throw new ArgumentException();
            }
            else
            {
                i_Vehicle.PowerSource.CurrentPowerSourceAmount += hoursToCharge;
            }
        }

        public Fuel.eFuelType GetFuelType(Vehicle i_Vehicle)
        {
            return (i_Vehicle.PowerSource as Fuel).FuelType;
        }

        public float GetAmountOfFuelRemaining(Vehicle i_Vehicle)
        {
            return (i_Vehicle.PowerSource as Fuel).CurrentFuelAmount;
        }

        public float GetMaxFuelTankCapacity(Vehicle i_Vehicle)
        {
            return (i_Vehicle.PowerSource as Fuel).MaxFuelAmount;
        }

        public void RefuleGasTank(Vehicle i_Vehicle , float i_FuelAmount , Fuel.eFuelType i_FuelType)
        {
            Fuel fuelPoweredVehicle = (i_Vehicle.PowerSource as Fuel);
            if (i_FuelType == fuelPoweredVehicle.FuelType)
            {
                if (fuelPoweredVehicle.CurrentFuelAmount + i_FuelAmount <= fuelPoweredVehicle.MaxFuelAmount)
                {
                    fuelPoweredVehicle.CurrentFuelAmount += i_FuelAmount;
                }
                else
                {
                    throw new ValueOutOfRangeException(0,fuelPoweredVehicle.MaxFuelAmount);
                }
            }
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
