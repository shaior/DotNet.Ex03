using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_Model;
        protected readonly string r_LicenseNumber;
        protected readonly PowerSource m_VehiclePowerSource;
        protected float m_EnergyPercentage;
        protected List<Wheel> m_Wheels;
        public static readonly List<Vehicle> r_VehiclesList = new List<Vehicle>();
        
        
        public Vehicle(string i_ModelName, string i_LicenseNumber,float i_RemainingPowerSupply, PowerSource.ePowerSupply i_VehiclePowerSource)
        {
            this.r_Model = i_ModelName;
            this.r_LicenseNumber = i_LicenseNumber;
            this.m_EnergyPercentage = i_RemainingPowerSupply;
            this.m_Wheels = new List<Wheel>();

            r_VehiclesList.Add(this);

            if (i_VehiclePowerSource == PowerSource.ePowerSupply.Battery)
            {
                m_VehiclePowerSource = new Battery();
            }
            else
            {
                m_VehiclePowerSource = new Fuel();
            }
        }

        public PowerSource PowerSource
        {
            get
            {
                return m_VehiclePowerSource;
            }
        }

        public List<Vehicle> VehiclesList
        {
            get
            {
                return r_VehiclesList;
            }
        }
        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }
        public enum eVehicleType
        {
            Car = 1,
            Motorcycle,
            Truck
           
        }
        public abstract void AssignEnergySourceToVehicle();

    }
}
