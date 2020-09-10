﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageInfo:Garage
    {
        private Vehicle m_Vehicle;
        private string m_OwnerPhoneNumber;
        private string m_OwnerName;
        private eCurrentVehicleState m_CurrentVehicleState;
        private static readonly Dictionary<string, GarageInfo> m_CurrentGarageVehicles = new Dictionary<string, GarageInfo>();
        

        public GarageInfo(Vehicle i_newVehicle, string i_OwnerPhoneNumber, string i_OwnerName)
        {
            this.m_Vehicle = i_newVehicle;
            this.m_OwnerName = i_OwnerName;
            this.m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            

        }

      

        public static Dictionary<string, GarageInfo> CurrentGarageVehicles
        {
            get
            {
                return m_CurrentGarageVehicles;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
            set
            {
                m_Vehicle = value;
            }
        }
        public eCurrentVehicleState VehicleState
        {
            get
            {
                return m_CurrentVehicleState;
            }
            set
            {
                m_CurrentVehicleState = value;
            }
        }
        public enum eCurrentVehicleState
        {
            CurrentlyRepairing = 1,
            Repaired,
            PaidUp
        }
       

        //TODO: CHANGE STATUS
        public void InsertVehicleToGarageForTreatment(string i_LicensePlate)
        {
            
            m_CurrentGarageVehicles.Add(i_LicensePlate,this);
            this.m_CurrentVehicleState = eCurrentVehicleState.CurrentlyRepairing;

        }
    }
}
