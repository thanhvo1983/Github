using System;
using System.Collections.Generic;
using System.Text;
using Kvics.HotMill.BL;

namespace Kvics.HotMill.Forms
{
    public class SimulationCalculateEventArgs : EventArgs
    {
        protected T900 _T900 = null;
        protected int _Time = 1;
        protected SimulationType _Type = SimulationType.Simulation1;

        public SimulationCalculateEventArgs(T900 t900, int time, SimulationType type)
            : base()
        {
            _T900 = t900;
            _Time = time;
            _Type = type;
        }

        public T900 T900
        {
            get
            {
                return _T900;
            }
            set
            {
                _T900 = value;
            }
        }

        public int Time
        {
            get
            {
                return _Time;
            }
            set
            {
                _Time = value;
            }
        }

        public SimulationType Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
            }
        }
    }

    public enum SimulationType
    {
        Simulation1,
        Simulation2,
        Simulation1Clear,
        Simulation2Clear
    }

    public delegate Gamen SimulationCalculate_EventHandler(object sender, SimulationCalculateEventArgs e);

    public delegate void FormFinishSupport_KeyEventHandler(object sender, System.Windows.Forms.Keys keyData);
}
