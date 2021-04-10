using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Business_Managing
{
    class SwappedLPG : Goods // Konsep Inheritance
    {

        private double lpgAmount = 150; // kilogram
        public double maxStock { get => lpgAmount; set => lpgAmount = value; }

        public SwappedLPG(string gdsType, double Stock, string msrUnit) : base(gdsType, Stock, msrUnit)
        {
            this.gdsType = gdsType;
            this.Stock = Stock;
            this.msrUnit = msrUnit;
        }

        public void AddLPGCylinder(int amount)
        {
            maxStock += amount;
        }

        public double MaxToAdd()
        {
            return maxStock - Stock;
        }

    }

}
