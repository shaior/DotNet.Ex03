using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageManager
    {
        /// <summary>
        /// garage menu.
        /// </summary>
        public static void GarageMenu()
        {
            Console.WriteLine("Welcome To A&S Garage Manager! ");
              bool exit = false;
            while (!exit)
            {
                string choice;
                Console.WriteLine("Type (1-8) to select from Below: " + Environment.NewLine);
                Console.WriteLine(
                    "1.Create new vehicle and insert it to the garage." + Environment.NewLine +
                    "2.Show vehicle list with their status." + Environment.NewLine +
                    "3.Change vehicle status in the garage." + Environment.NewLine +
                    "4.Fill all the vehicle to max by license number." + Environment.NewLine +
                    "5.Refuel gas tank by license number." + Environment.NewLine +
                    "6.Charge car battery by license." + Environment.NewLine +
                    "7.Show full vehicle details by license number."+Environment.NewLine+
                    "8.Quit.");

                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateNewVehicle();
                        break;
                    case "2":
                        ShowAllGarageVehiclesLicenseNumber();
                        break;
                    case "3":
                        ChangeVehicleStatus();
                        break;
                    case "4":
                        FillWheelToMaxByLicenseNumber();
                        break;
                    case "5":
                        RefuelGasTank();
                        break;
                    case "6":
                        RechargeBattery();
                        break;
                    case "7":
                        ShowFullVehicleDetailsByLicenseNumber();
                        break;
                    case "8":
                        exit = true;
                        break;
                }
            }

         
        }
        /// <summary>
        /// changing vehicle status.
        /// </summary>
        public static void ChangeVehicleStatus()
        {
            Console.WriteLine("Please enter Vehicle license number to change it's status:");
            string vehicleLicenseNumber = Console.ReadLine();
            Console.WriteLine("Please enter Vehicle new status: 1.Currently repairing 2.Repaired 3.Paid up ");
            string vehicleNewStatus = Console.ReadLine();
            GarageInfo.eCurrentVehicleState newVehicleState = (GarageInfo.eCurrentVehicleState)int.Parse(vehicleNewStatus);
            GarageInfo.ChangeVehicleStatus(vehicleLicenseNumber, newVehicleState);
        }

        /// <summary>
        /// creating new vehicle.
        /// </summary>
        public static void CreateNewVehicle()
        {
            string typeOfVehicleInput = string.Empty;
            try
            {
                Console.WriteLine("Please choose the type of the vehicle :" + Environment.NewLine+ "1.Car " + Environment.NewLine +
                                  "2.Motorcycle" + Environment.NewLine + "3.Truck");
                typeOfVehicleInput = Console.ReadLine();
                if (int.Parse(typeOfVehicleInput) >= 1 && int.Parse(typeOfVehicleInput) <= 3)
                {
                    bool checkPlateNumber = true;
                    while (checkPlateNumber)
                    {
                        
                        Console.WriteLine("Please enter license plate number");
                        string licensePlateNumberInput = Console.ReadLine();

                        checkPlateNumber = Garage.CheckIfVehicleExistsInGarage(licensePlateNumberInput);
                        
                        if (checkPlateNumber)
                        {
                            Console.WriteLine("This Vehicle already exists in the garage. starting treatment...");
                            
                        }
                        else
                        {
                            Vehicle.eVehicleType vehicleTypePick = Vehicle.GetVehicleTypeByDigit(int.Parse(typeOfVehicleInput));
                            string vehicleModelName = string.Format("Pleae enter your {0}'s Model: ",vehicleTypePick);
                            Console.WriteLine(vehicleModelName); 
                            string modelNameInput = Console.ReadLine();
                            string vehiclePowerSupply = string.Format("Please enter your {0}'s Power Supply. 1.Fuel 2.Battery :  ",vehicleTypePick);
                            Console.WriteLine(vehiclePowerSupply);
                            string vehiclePowerSupplyInput = Console.ReadLine();
                            PowerSource.ePowerSupply powerSupply = PowerSource.getPowerSupplyType(vehiclePowerSupplyInput);
                            
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
                            
                            string manufacturerName = string.Format("Please enter your {0}'s tires Manufactuer Name: ", vehicleTypePick);
                            Console.WriteLine(manufacturerName);
                            string manufacturerNameInput = Console.ReadLine();
                            
                            Vehicle createdVehicle = GarageLogic.VehiclesCreator.CreateVehicle(vehicleTypePick, modelNameInput,
                                licensePlateNumberInput, float.Parse(powerSupplyRemainingInput), powerSupply,
                                manufacturerNameInput);
                            AddVehicleDetails(createdVehicle);
                            AddVehicleToTreatment(createdVehicle);
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

        /// <summary>
        /// showing all vehicles in the garage.
        /// </summary>
        public static void ShowAllGarageVehiclesLicenseNumber()
        {
            Console.WriteLine("Choose Vehicle state to filter: 1.Currently Repairing 2.Repaired 3.Paid Up");
            string choice = Console.ReadLine();
            GarageInfo.eCurrentVehicleState state = (GarageInfo.eCurrentVehicleState)int.Parse(choice);  
            foreach (GarageInfo info in GarageInfo.CurrentGarageVehicles.Values)
            {
                if (info.VehicleState == state)
                {
                    Console.WriteLine(string.Format(@"{0} : {1}",info.Vehicle.LicenseNumber, state));
                }
            }
        }

        /// <summary>
        /// show full details on vehicle by license number.
        /// </summary>
        public static void ShowFullVehicleDetailsByLicenseNumber()
        {
            Console.WriteLine("Please enter Vehicle license number to get all details:");
            string vehicleLicenseNumber = Console.ReadLine();
            string allVehicleDetails = string.Empty;

            allVehicleDetails = Garage.GetFullVehicleDetails(vehicleLicenseNumber);

            Console.WriteLine(allVehicleDetails);
        }

        /// <summary>
        /// adding vehicle to treatment status.
        /// </summary>
        /// <param name="i_Vehicle"> vehicle.</param>
        public static void AddVehicleToTreatment(Vehicle i_Vehicle)
        {
            const int phoneNumberLength = 10;
            Console.WriteLine("Please add owner name: ");
            string ownerName = Console.ReadLine();
            Console.WriteLine("Please add owner phone number: ");
            string ownerNumber = Console.ReadLine();
            if (ownerNumber.Length != phoneNumberLength)
            {
                throw new ArgumentException();
            }
            GarageInfo vehicleToTreatment = new GarageInfo(i_Vehicle, ownerNumber, ownerName);
            vehicleToTreatment.InsertVehicleToGarageForTreatment(i_Vehicle.LicenseNumber);
        }

        /// <summary>
        /// adding vehicle details.
        /// </summary>
        /// <param name="i_Vehicle"></param>
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
                   
                }
                else if (i_Vehicle.PowerSource is Fuel)
                {
                    GetFuelType(i_Vehicle);
                    GetAmountOfFuelRemaining(i_Vehicle);
                    GetMaxFuelTankCapacity(i_Vehicle);
                    
                }
            }

            
        }

        /// <summary>
        /// adding car color.
        /// </summary>
        /// <param name="i_Vehicle"></param>
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

        /// <summary>
        /// adding car door number.
        /// </summary>
        /// <param name="i_Vehicle"></param>
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

        /// <summary>
        /// adding motorcycle engine volume.
        /// </summary>
        /// <param name="i_Vehicle"></param>
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

        /// <summary>
        /// adding motorcycle license type.
        /// </summary>
        /// <param name="i_Vehicle"></param>
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

        /// <summary>
        /// verify if the truck care dangerous goods.
        /// </summary>
        /// <param name="i_Vehicle"></param>

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

        /// <summary>
        /// add truck cargo volume.
        /// </summary>
        /// <param name="i_Vehicle"></param>
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

        /// <summary>
        /// get the battery time left.
        /// </summary>
        /// <param name="i_Vehicle"></param>
        /// <returns>hours left</returns>

        public static float GetBatteryTimeLeft(Vehicle i_Vehicle)
        {
            return (i_Vehicle.PowerSource as Battery).CurrentPowerSourceAmount;
        }

        /// <summary>
        /// get max battery life time capacity.
        /// </summary>
        /// <param name="i_Vehicle"></param>
        /// <returns>the number of max time the battery is able to work.</returns>
        public static float GetMaxBatteryLifeTime(Vehicle i_Vehicle)
        {
            return i_Vehicle.PowerSource.MaxPowerSourceAmount;
        }

        /// <summary>
        /// charge battery.
        /// </summary>
        public static void RechargeBattery()
        {
            Console.WriteLine("Please Provide License number to recharge car Battery: ");
            string licenseNumber = Console.ReadLine();
            Console.WriteLine("Please Provide amount of minutes to recharge: ");
            string rechargeAmount = Console.ReadLine();

            Battery.RechargeVehicleBattery(licenseNumber,rechargeAmount);
        }

        /// <summary>
        /// gets the fuel type of a vehicle.
        /// </summary>
        /// <param name="i_Vehicle"></param>
        /// <returns>fuel type.</returns>
        public static Fuel.eFuelType GetFuelType(Vehicle i_Vehicle)
        {
            return (i_Vehicle.PowerSource as Fuel).FuelType;
        }

        /// <summary>
        /// get amount of fuel remaining for vehicle.
        /// </summary>
        /// <param name="i_Vehicle"></param>
        /// <returns></returns>
        public static float GetAmountOfFuelRemaining(Vehicle i_Vehicle)
        {
            return (i_Vehicle.PowerSource as Fuel).CurrentFuelAmount;
        }

        /// <summary>
        /// get the max fuel tank capacity for a vehicle.
        /// </summary>
        /// <param name="i_Vehicle"></param>
        /// <returns></returns>

        public static float GetMaxFuelTankCapacity(Vehicle i_Vehicle)
        {
            return (i_Vehicle.PowerSource as Fuel).MaxFuelAmount;
        }

        /// <summary>
        /// refuel gas tank.
        /// </summary>
        public static void RefuelGasTank()
        {
            Console.WriteLine("Please Provide License number to Refuel car: ");
            string licenseNumber = Console.ReadLine();
            Console.WriteLine("Please Provide Fuel amount to refuel: ");
            string fuelAmount = Console.ReadLine();
            Console.WriteLine(string.Format("Please provide fuel type: 1.Octan98 2.Octan96 3.Octan95 4.Soler"));
            string fuelType = Console.ReadLine();
         
            Fuel.Refule(licenseNumber, fuelType,fuelAmount);
        }

        /// <summary>
        /// fill the wheel to max by car license number
        /// </summary>
        public static void FillWheelToMaxByLicenseNumber()
        {
            
                Console.WriteLine("Please Provide License number to inflate wheels to maximum: ");
                string licenseNumber = Console.ReadLine();

                Wheel.InflateWheelsToMax(licenseNumber);

        }

        public static void Main()
        {
            GarageMenu();
            Console.ReadLine();
        }
    }
}
