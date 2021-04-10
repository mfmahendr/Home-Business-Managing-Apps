using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Business_Managing
{
    class Credit : Goods // Konsep Inheritance
    {
        public Credit(string gdsType, double Stock, string msrUnit) : base(gdsType, Stock, msrUnit)
        {
            this.gdsType = gdsType;
            this.Stock = Stock;
            this.msrUnit = msrUnit;
        }

        // Konsep Polimorphism
        public void Sub(string priceListKey)
        {
            try { Stock -= Convert.ToDouble(priceListKey); }
            catch(Exception e)
            {
                Console.WriteLine("Error, " + e.Message);
            }
        }
    }
}
