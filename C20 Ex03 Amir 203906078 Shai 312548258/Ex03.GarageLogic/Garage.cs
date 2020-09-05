using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Garage
    {
        private string m_OwnerName;
        private string m_OwnerNumber;

        public enum eCurrentVehicleState
        {
            CurrentlyRepairing = 0,
            Repaired,
            PaidUp
        }
    }
}
