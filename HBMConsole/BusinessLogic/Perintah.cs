using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBMConsole.BusinessLogic
{
    public static class Perintah
    {
        private static int pilihan;

        public static int Masukan()
        {
            pilihan = -1;
            Console.WriteLine("\n\tSilakan pilih menu yang tersedia di atas");
            Console.Write("\tPilihan: ");
            try
            {
                pilihan = int.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException)
            {
                Pesan.Warning("Pilihan tidak boleh kosong");
            }
            catch (FormatException)
            {
                Pesan.Error("Masukan tidak boleh karakter lain selain angka"); 
            }
            catch (Exception ex)
            {
                Pesan.Error( ex.Message);
            }

            return pilihan;
        }
    }
}
