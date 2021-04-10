using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Business_Managing
{
    public abstract class Goods // Abstraksi
    {
        // Abstraksi field dan method
        public Dictionary<string, double> priceList = new Dictionary<string, double>();
        private string type;
        private double stock;
        private string measureUnit;


        public string gdsType { get => type; set => type = value; }
        public double Stock { get => stock; set => stock = value; }
        public string msrUnit { get => measureUnit; set => measureUnit = value; }


        // Constructor
        public Goods(string gdsType, double Stock, string msrUnit)
        {
            this.gdsType = gdsType;
            this.Stock = Stock;
            this.msrUnit = msrUnit;
        }

        public void Add(double amount) //Menambah jumlah stok
        {
             this.Stock += amount;
        }

        public void Sub(double amount, string priceListKey)  // Mungkin karena rusak atau hilang
        {
            if (priceList.ContainsKey(priceListKey))
            {
                double temp;
                try
                {
                    temp = Convert.ToDouble(priceListKey);
                    Stock -= amount * temp;
                }
                catch (Exception e) { Console.WriteLine("Error, " + e.Message); }
            }
        }


        public void Info()
        {
            Console.WriteLine("Jenis : " + type); // untuk pulsa karena gk ada ukuran
            Console.WriteLine($"Jumlah stok : {stock} {measureUnit}");
        }

        public virtual void ChangeInfo()
        {

        }
    }
}
