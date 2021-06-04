using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Business_Managing_App.BusinessLogic
{
    public class HitungPendapatan
    {
        public int CalculateRevenue(int quantity, int price)
        {
            return price * quantity;
        }
        public static float CalculateRevenue(float quantity, float price)
        {
            return price * quantity;
        }

        public static int CalculateGrossProfit(int totalRevenue, int totalExpense)
        {
            return totalRevenue - totalExpense;
        }
        public static float CalculateGrossProfit(float totalRevenue, float totalExpense)
        {
            return totalRevenue - totalExpense;
        }
        public static double CalculateGrossProfit(double totalRevenue, double totalExpense)
        {
            return totalRevenue - totalExpense;
        }

    }
}
