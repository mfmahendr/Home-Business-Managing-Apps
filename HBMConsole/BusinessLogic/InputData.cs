using HBMConsole.Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBMConsole.BusinessLogic
{
    public static class InputData
    {
        public static string Teks(string label)
        {
            Console.Write("\t{0, -16}:", label);
            string teksMasukan = Console.ReadLine();

            if (string.IsNullOrEmpty(teksMasukan))
            {
                return Teks(label);
            }

            return teksMasukan;
        }

        public static string IdBaru()
        {
            Barang barang = new Barang();

            string idBarang = Teks("Id");

            if (barang.CekIdBarang(idBarang))
            {
                Pesan.Warning("Barang yang Anda masukkan sudah ada");
                return IdBaru();
            }

            return idBarang;
        }

        public static string IdTersedia()
        {
            Barang barang = new Barang();

            string idBarang = string.Empty;
            idBarang = Teks("Id");

            if (!barang.CekIdBarang(idBarang))
            {
                Pesan.Warning("Id barang yang Anda masukkan tidak ada. Silakan coba lagi...\n");
                return IdTersedia();
            }

            return idBarang;
        }

        public static double AngkaDouble(string label)
        {
            string angkaMasukan = Teks(label);
            return double.Parse(angkaMasukan);
        }

        public static int AngkaInt(string label)
        {
            string angkaMasukan = Teks(label);
            return int.Parse(angkaMasukan);
        }

    }
}
