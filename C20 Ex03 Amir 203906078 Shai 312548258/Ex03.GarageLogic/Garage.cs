using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private string m_OwnerName;
        private string m_OwnerNumber;
        protected readonly List<Vehicle> r_VehiclesList = new List<Vehicle>();

        private Dictionary<string, eCurrentVehicleState> m_CurrentGarageVehicles = new Dictionary<string, eCurrentVehicleState>();
        
        public Dictionary<string, eCurrentVehicleState> VehiclesState
        {
            get
            {
                return m_CurrentGarageVehicles;
            }
        }

        //methods
        //methd changeVehicleState
        //addvehicletoTreatment
        //checkIfVehicleExist

        public enum eCurrentVehicleState
        {
            CurrentlyRepairing = 0,
            Repaired,
            PaidUp
        }
    }
}
