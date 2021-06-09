using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBMConsole.BusinessLogic
{
    public class HitungPendapatan
    {
        public int CalculateRevenue(int quantity, int price)
        {
            return price * quantity;
        }
        public float CalculateRevenue(float quantity, float price)
        {
            return price * quantity;
        }
        public double CalculateRevenue(double quantity, double price)
        {
            return price * quantity;
        }

        public int CalculateGrossProfit(int totalRevenue, int totalExpense)
        {
            return totalRevenue - totalExpense;
        }
        public float CalculateGrossProfit(float totalRevenue, float totalExpense)
        {
            return totalRevenue - totalExpense;
        }
        public double CalculateGrossProfit(double totalRevenue, double totalExpense)
        {
            return totalRevenue - totalExpense;
        }

    }
}
