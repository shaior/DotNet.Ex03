using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car:Vehicle
    {
        private eCarColor m_Color;
        private eNumberOfDoors m_DoorsNumber;
        

      

        public enum eCarColor
        {
            Grey,
            White,
            Green,
            Red
        }
        public enum eNumberOfDoors
        {
            Two,
            Three,
            Four,
            Five
        }
    }
}
