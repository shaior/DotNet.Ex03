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
                    Console.WriteLine("Please sign Vehicle for Treatment in the garage.");
                    break;
                case "7":
                    Console.WriteLine("Please enter Vehicle license number to get all details:");
                    string vehicleLicenseNumber = Console.ReadLine();
                    string allVehicleDetails = string.Empty;

                    if (Garage.CheckIfVehicleExistsInGarage(vehicleLicenseNumber))
                    {
                        foreach (Vehicle vehicle in Vehicle.r_VehiclesList)
                        {
                            if (vehicle.LicenseNumber == vehicleLicenseNumber)
                            {
                                allVehicleDetails = Vehicle.GetAllVehicleDetails(vehicle);
                                break;
                            }
                        }
                        
                        Console.WriteLine(allVehicleDetails);
                    }

                    break;
            }
        }

        public static void SignVehicleForTreatment()
        {

        }

        public static void CreateNewVehicle()  //SECTION 1
        {
            string typeOfVehicleInput = string.Empty;
            try
            {
                Console.WriteLine("Please choose the type of the vehicle :" + Environment.NewLine+" 1.Car " + Environment.NewLine +
                                  "2.Motorcycle" + Environment.NewLine + "3.Truck");
                typeOfVehicleInput = Console.ReadLine();
                if (int.Parse(typeOfVehicleInput) >= 1 && int.Parse(typeOfVehicleInput) <= 3)
                {
                    bool checkPlateNumber = true;
                    while (checkPlateNumber)
                    {

                        //check if license number exists in garage
                        Console.WriteLine("Please enter license plate number");
                        string licensePlateNumberInput = Console.ReadLine();

                        checkPlateNumber = GarageLogic.Garage.CheckIfVehicleExistsInGarage(licensePlateNumberInput);
                        //checkPlateNumber = UserInputValidation.LicensePlateValidation(licensePlateNumber);
                        if (checkPlateNumber)
                        {
                            Console.WriteLine("This Vehicle already exists in the garage. starting treatment...");
                            GarageLogic.Garage.VehiclesState.Add(licensePlateNumberInput,Garage.eCurrentVehicleState.CurrentlyRepairing);
                        }
                        else
                        {
                            GarageLogic.Garage.VehiclesState.Add(licensePlateNumberInput,
                                Garage.eCurrentVehicleState.CurrentlyRepairing); /// TODO: NEED TO CHECK THIS LINE IF NECCESARY
                            Vehicle.eVehicleType vehicleTypePick =
                                Vehicle.GetVehicleTypeByDigit(int.Parse(typeOfVehicleInput));
                            string vehicleModelName = string.Format("Pleae enter your {0} Model: ",vehicleTypePick);
                            Console.WriteLine(vehicleModelName); 
                            string modelNameInput = Console.ReadLine();
                            //////////////////////////////////////////////
                            string vehiclePowerSupply = string.Format("Please enter your {0}'s Power Supply. 1.Fuel 2.Battery :  ",vehicleTypePick);
                            Console.WriteLine(vehiclePowerSupply);
                            string vehiclePowerSupplyInput = Console.ReadLine();
                            PowerSource.ePowerSupply powerSupply = PowerSource.getPowerSupplyType(vehiclePowerSupplyInput);
                            //////////////////////////////////////////////////
                            string powerSupplyRemaining = string.Empty;
                            if (powerSupply == PowerSource.ePowerSupply.Fuel)
                            {
                                 powerSupplyRemaining = string.Format("Please enter remaining fuel in your {0} by liters: ", vehicleTypePick);
                            }
                            else if(powerSupply == PowerSource.ePowerSupply.Battery)
                            {
                                 powerSupplyRemaining = string.Format("Please enter remaining Battery time in your {0} by hours: ", vehicleTypePick);
                            }

                            Console.WriteLine(powerSupplyRemaining);
                            string powerSupplyRemainingInput = Console.ReadLine();
                            /////////////////////////////////////////////////
                            string manufacturerName = string.Format("Please enter your {0}'s tires Manufactuer Name: ", vehicleTypePick);
                            Console.WriteLine(manufacturerName);
                            string manufacturerNameInput = Console.ReadLine();
                            /////////////////////////////////////////////////////
                            Vehicle createdVehicle = GarageLogic.VehiclesCreator.CreateVehicle(vehicleTypePick, modelNameInput,
                                licensePlateNumberInput, float.Parse(powerSupplyRemainingInput), powerSupply,
                                manufacturerNameInput);
                            AddVehicleDetails(createdVehicle);

                            Console.WriteLine();
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                string exceptionType = string.Format("input is not valid - {0}", ex.Message);
                Console.WriteLine(exceptionType);
            }

        }
        
        public static void AddVehicleDetails(Vehicle i_Vehicle)
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
                    //ChargeBattery(i_Vehicle);  no need to use here - section 6
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

        public static void GetAllGarageVehiclesLicenseNumber()  //SECTION 2
        {

            // TODO : need to write new writline method for dictionary print
            // todo: need to filter by current vehicle state (different method)
            //foreach (Dictionary<string,Garage.eCurrentVehicleState> vehicle in Garage.VehiclesState)
            //{
            //    Console.WriteLine("{0}  :  {1}",Garage.VehiclesState.Keys , Garage.VehiclesState.Values);
            //}
        }

        public static void AddCarColor(Vehicle i_Vehicle)
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

        public static void AddCarDoors(Vehicle i_Vehicle)
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

        public static void AddMotorcycleEngineVolume(Vehicle i_Vehicle)
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

        public static void AddMotorcycleLicenseType(Vehicle i_Vehicle)
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

        public static void IsCarryingDangerousGoods(Vehicle i_Vehicle)
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

        public static void AddCargoVolume(Vehicle i_Vehicle)
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

        public static float GetBatteryTimeLeft(Vehicle i_Vehicle)
        {
            return i_Vehicle.PowerSource.CurrentPowerSourceAmount;
        }

        public static float GetMaxBatteryLifeTime(Vehicle i_Vehicle)
        {
            return i_Vehicle.PowerSource.MaxPowerSourceAmount;
        }

        public static void ChargeBattery(Vehicle i_Vehicle)
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

        public static Fuel.eFuelType GetFuelType(Vehicle i_Vehicle)
        {
            return (i_Vehicle.PowerSource as Fuel).FuelType;
        }

        public static float GetAmountOfFuelRemaining(Vehicle i_Vehicle)
        {
            return (i_Vehicle.PowerSource as Fuel).CurrentFuelAmount;
        }

        public static float GetMaxFuelTankCapacity(Vehicle i_Vehicle)
        {
            return (i_Vehicle.PowerSource as Fuel).MaxFuelAmount;
        }

        public static void RefuleGasTank(Vehicle i_Vehicle , float i_FuelAmount , Fuel.eFuelType i_FuelType)
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
            CreateNewVehicle();

            Console.WriteLine();
        }
    }
}
