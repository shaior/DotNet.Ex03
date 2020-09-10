using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageTreatment:Garage
    {

        public GarageTreatment(Vehicle i_newVehicle, string i_OwnerPhoneNumber, string i_OwnerName) : base(i_newVehicle, i_OwnerPhoneNumber, i_OwnerName)
        {
        }
    }
}
