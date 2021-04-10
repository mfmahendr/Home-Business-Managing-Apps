 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Business_Managing
{
    public class RefilledWater : Goods  // Konsep Inheritance
    {

        public RefilledWater(string gdsType, double Stock, string msrUnit) : base(gdsType, Stock, msrUnit)
        {
            this.gdsType = gdsType;
            this.Stock = Stock;
            this.msrUnit = msrUnit;
        }

        public new void Info()
        {
            Console.WriteLine($" Jenis : {gdsType}"); // untuk pulsa karena gk ada ukuran
            Console.WriteLine($" Jumlah stok : {Stock} {msrUnit}");
            Console.WriteLine("\nUkuran");
            Console.WriteLine("");
            Console.WriteLine(" Daftar harga ");
            foreach(var i in priceList.Keys)
            {
                Console.WriteLine($"\tHarga untuk ukuran {i} = {priceList[i]}\t");
            }
        }
    }
}
