using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Business_Managing
{
    class BottledHoney : Goods  // Konsep Inheritance
    {

        public BottledHoney(string gdsType, double Stock, string msrUnit) : base(gdsType, Stock, msrUnit)
        {
            this.gdsType = gdsType;
            this.Stock = Stock;
            this.msrUnit = msrUnit;
        }

        public new void Info()
        {
            Console.WriteLine($" Jenis : {gdsType}"); // untuk pulsa karena gk ada ukuran
            Console.WriteLine($" Jumlah stok : {Stock} {msrUnit}");
            Console.WriteLine("");
            Console.WriteLine(" Daftar harga ");
            foreach (var i in priceList.Keys)
            {
                Console.WriteLine($"\t{i} {msrUnit} = {priceList[i]}\t");
            }
        }
    }
}
