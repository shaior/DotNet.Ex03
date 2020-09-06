﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class PowerSource
    {
        private float m_CurrentPowerSourceAmount;
        private float m_MaxPowerSourceAmount;
        public enum ePowerSupply
        {
            Fuel = 0,
            Battery = 1
        }

        public float CurrentPowerSourceAmount
        {
            get
            {
                return m_CurrentPowerSourceAmount;
            }

            set
            {
                m_CurrentPowerSourceAmount = value;
            }
        }

        public float MaxPowerSourceAmount
        {
            get
            {
                return m_MaxPowerSourceAmount;
            }

            set
            {
                m_MaxPowerSourceAmount = value;
            }
        }

    }
}
