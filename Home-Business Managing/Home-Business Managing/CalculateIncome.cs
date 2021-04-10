using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Business_Managing
{
    public static class CalculateIncome // Single Responsibility Principle
    {                                   // di mana tanggung jawab class ini hanya untuk melakukan perhitungan data untuk laba-rugi
        // Polimorphism static          // artinya ketika class ini diubah maka alasannya pasti ada pada perhitungan income-nya
        public static int CalculateRevenue(int quantity, int price)
        {
            return price * quantity;
        }

        // Polimorphism static
        public static double CalculateRevenue(double quantity, double price)
        {
            return price * quantity;
        }

        // Polimorphism static
        public static double CalculateGrossProfit(double totalRevenue, double totalExpense, out bool isProfit)
        {
            double grossProfit;
            bool temp = true;
            if (totalRevenue == totalExpense)
            {
                temp = false;
                grossProfit = 0;
            }
            else
            {
                grossProfit = totalRevenue - totalExpense;
                if (totalRevenue < totalExpense)
                {
                    temp = false;
                    grossProfit *= -1;
                }
            }
            isProfit = temp;
            return grossProfit;
        }

        // Polimorphism static
        public static int CalculateGrossProfit(int totalRevenue, int totalExpense, out bool isProfit)
        {
            int grossProfit;
            bool temp = true;
            if (totalRevenue == totalExpense)
            {
                temp = false;
                grossProfit = 0;
            }
            else
            {
                grossProfit = totalRevenue - totalExpense;
                if (totalRevenue < totalExpense)
                {
                    temp = false;
                    grossProfit *= -1;
                }
            }
            isProfit = temp;
            return grossProfit;
        }

        // Open-Closed principle 
        // karena dalam class ini, ketika terjadi perubahan
        // cara menghitung, maka method-method lain yang sudah ada tidak
        // perlu dimodifikasi, cukup ditambahkan pada saat ingin menggunakan
        // class ini lagi nantinya
        public static double CalculateGrossProfit(double totalRevenue, double totalExpense)
        {
            return totalRevenue - totalExpense;
        }

        public static int CalculateGrossProfit(int totalRevenue, int totalExpense)
        {
            return totalRevenue - totalExpense;
        }
    }
}
