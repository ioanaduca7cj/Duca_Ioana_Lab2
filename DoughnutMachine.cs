using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Duca_Iona_Lab2
{
    class DoughnutMachine : Component // (1)
    {
        private DoughnutType mFlavor; // (4)
        public DoughnutType Flavor
        {
            get
            {
                return mFlavor;
            }
            set
            {
                mFlavor = value;
            }
        }
        private System.Collections.ArrayList mDoughnuts = new System.Collections.ArrayList(); // (5)
        public Doughnut this[int Index]
        {
            get
            {
                return (Doughnut)mDoughnuts[Index];
            }
            set
            {
                mDoughnuts[Index] = value;
            }
        }
        public delegate void DoughnutCompleteDelegate();
        public event DoughnutCompleteDelegate DoughnutComplete;

        DispatcherTimer doughnutTimer; // (7)
        private void InitializeComponent() // (8)
        {
            this.doughnutTimer = new DispatcherTimer();
            this.doughnutTimer.Tick += new System.EventHandler(this.doughnutTimer_Tick);
        }
        public DoughnutMachine() // (9)
        {
            InitializeComponent();
        }

        private void doughnutTimer_Tick(object sender, EventArgs e)
        {
            Doughnut aDoughnut = new Doughnut(this.Flavor);
            mDoughnuts.Add(aDoughnut);
            DoughnutComplete();
        }
        public bool Enabled // (11)
        {
            set
            {
                doughnutTimer.IsEnabled = value;
            }
        }
        public int Interval
        {
            set
            {
                doughnutTimer.Interval = new TimeSpan(0, 0, value);
            }
        }

        public void MakeDoughnut(DoughnutType dFlavor) // (12)
        {
            Flavor = dFlavor;
            switch (Flavor)
            {
                case DoughnutType.Glazed: Interval = 3; break;
                case DoughnutType.Sugar: Interval = 2; break;
                case DoughnutType.Lemon: Interval = 5; break;
                case DoughnutType.Chocolate: Interval = 7; break;
                case DoughnutType.Vanilla: Interval = 4; break;
            }
            doughnutTimer.Start();
        }

    }

    public enum DoughnutType // 2
    {
        Glazed,
        Sugar,
        Lemon,
        Chocolate,
        Vanilla
    }

    class Doughnut // 3
    {
        private DoughnutType mFlavor;
        public DoughnutType Flavor
        {
            get
            {
                return mFlavor;
            }
            set
            {
                mFlavor = value;
            }
        }

        private float mPrice = .50F;
        public float Price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }
        private readonly DateTime mTimeOfCreation;
        public DateTime TimeOfCreation
        {
            get
            {
                return mTimeOfCreation;
            }
        }
        public Doughnut(DoughnutType aFlavor) // constructor
        {
            mTimeOfCreation = DateTime.Now;
            mFlavor = aFlavor;
        }
    }
}