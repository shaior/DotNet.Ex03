﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck:Vehicle
    {
        private bool m_ContainsDangerousGoods;
        private float m_CargoVolume;
        private const int k_NumberOfWheels = 16;

        public Truck(string i_ModelName, string i_LicenseNumber, float i_RemainingPowerSupply, PowerSource.ePowerSupply i_PowerSupply, string i_ManufacturerName)
            : base(i_ModelName, i_LicenseNumber, i_RemainingPowerSupply, i_PowerSupply)
        {
            
        }

        public bool ContainsDangerousGoods
        {
            get
            {
                return m_ContainsDangerousGoods;
            }
            set
            {
                m_ContainsDangerousGoods = value;
            }
        }
        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }
            set
            {
                m_CargoVolume = value;
            }
        }

        public override void AssignEnergySourceToVehicle()
        {
            ((Fuel)PowerSource).FuelType = Fuel.eFuelType.Soler;
            PowerSource.MaxPowerSourceAmount = Fuel.FuelTankSize.Truck;
        }

    }
}
