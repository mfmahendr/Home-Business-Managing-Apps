using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Business_Managing
{
    public class MenuUtama
    {
        public static int DaftarMenu()
        {
            Console.Clear();
            Console.WriteLine("|===================================================|");
            Console.WriteLine("|           Home Business Manager App Menu          |");
            Console.WriteLine("|---------------------------------------------------|");
            Console.WriteLine("| Berikut adalah menu-menu yang tersedia:           |");
            Console.WriteLine("| 0     : Keluar                                    |");
            Console.WriteLine("| 1     : Tampilkan informasi item yang dijual      |");
            Console.WriteLine("| 2     : Tampilkan laporan laba rugi               |");
            Console.WriteLine("| 3     : Ubah informasi produk                     |");
            Console.WriteLine("| 4     : Beli stok item                            |");
            Console.WriteLine("| 5     : Jual produk                               |");
            Console.WriteLine("| 6     : Logout                                    |");
            Console.WriteLine("|===================================================|");
            Console.Write("==> Pilihan (0-5): ");
            int inputMenu = Console.Read();
            return inputMenu;
        }

        private static void MasukKeMenu(int input)
        {
            switch (input)
            {
                case 0:
                    {
                        Console.WriteLine("Sampai jumpa lagi");
                        return;
                    }
                case 1:
                    {
                    INFO:
                        Console.Clear();
                        Console.WriteLine("=====================================================");
                        Console.WriteLine("Berikut adalah item yang ada");
                        for (int i = 0; i < listOfGoods.Count(); i++)
                        {
                            Console.WriteLine($" {i + 1}\t: {listOfGoods[i]}");
                        }
                        Console.WriteLine($" {listOfGoods.Count}\t: Semua");
                        Console.WriteLine(" 6\t: Kembali ke menu utama");
                        Console.WriteLine("=====================================================");
                        Console.WriteLine("==> Item apa yang ingin Anda lihat?");
                        string inputItem = Console.ReadLine();

                        if (inputItem == "1") { rflWater.Info(); }
                        else if (inputItem == "2") { btlHoney.Info(); }
                        else if (inputItem == "3") { credit.Info(); }
                        else if (inputItem == "4") { lpg.Info(); }
                        else if (inputItem == "5") { rflWater.Info(); btlHoney.Info(); credit.Info(); lpg.Info(); }
                        else if (inputItem == "6") { DaftarMenu(); }
                        else
                        {
                            Console.WriteLine("Pilihan tidak ada");
                            goto INFO;
                        }

                        break;
                    }
                case 2:
                    {
                        foreach (string product in revenueOf.Keys)
                        {
                            Console.WriteLine(product);
                            Console.WriteLine($"Total pendapatan {product} = {revenueOf[product]}");
                            Console.WriteLine($"Total biaya {product} = {expenseOf[product]}");
                            Console.WriteLine($"Penghasilan bruto dari {product} = {CalculateIncome.CalculateGrossProfit(revenueOf[product], expenseOf[product])}");
                        }
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Mari lihat dulu informasi produk");
                        Console.WriteLine("1. Isi ulang air galon");
                        rflWater.Info();
                        Console.WriteLine("2. Madu");
                        btlHoney.Info();
                        Console.WriteLine("3. Pulsa");
                        credit.Info();
                        Console.WriteLine("4. Gas LPG");
                        lpg.Info();
                        Console.WriteLine("5. Kembali ke menu");
                        while (true)
                        {
                            Console.WriteLine("\n Produk mana yang akan diubah?");
                            string inputToChange = Console.ReadLine();
                            if (inputToChange == "1") { rflWater.ChangeInfo(); }
                            else if (inputToChange == "2") { btlHoney.ChangeInfo(); }
                            else if (inputToChange == "3") { credit.ChangeInfo(); }
                            else if (inputToChange == "4") { lpg.ChangeInfo(); }
                            else if (inputToChange == "5") { goto MENU; }
                            else { Console.WriteLine("Pilihan tidak ditemukan, jangan ngadi2"); }
                        }
                    }
                case 4:
                    {
                    BELI:
                        Console.Clear();
                        Console.WriteLine("=====================================================");
                        Console.WriteLine("Berikut adalah item yang ada");
                        for (int i = 0; i < listOfGoods.Count(); i++)
                        {
                            Console.WriteLine($" {i + 1}\t: {listOfGoods[i]}");
                        }
                        Console.WriteLine($" {listOfGoods.Count}\t:  Kembali ke menu utama");
                        Console.WriteLine("=====================================================");
                        Console.WriteLine("==> Stok barang yang akan ditambah? ");
                        string inputBuyGoods = Console.ReadLine();
                        double inputBuyAmount;
                        double inputExpense;

                        if (inputBuyGoods == "1")
                        {
                            Console.WriteLine("==> Jumlah total liter air yang ditambah?");
                            inputBuyAmount = Convert.ToDouble(Console.Read());
                            Console.WriteLine("==> Total biaya yang dikeluarkan?");
                            inputExpense = Convert.ToDouble(Console.Read());
                            rflWater.Add(inputBuyAmount);
                            expenseOf[rflWater.gdsType] += inputExpense;
                        }
                        else if (inputBuyGoods == "2")
                        {
                            Console.WriteLine("==> Jumlah total gram yang ditambahkan?");
                            inputBuyAmount = Convert.ToDouble(Console.Read());
                            Console.WriteLine("==> Total biaya yang dikeluarkan?");
                            inputExpense = Convert.ToDouble(Console.Read());
                            btlHoney.Add(inputBuyAmount);
                            expenseOf[btlHoney.gdsType] += inputExpense;
                        }
                        else if (inputBuyGoods == "3")
                        {
                            Console.WriteLine("Jumlah pulsa yang daitambahkan?");
                            inputBuyAmount = Convert.ToDouble(Console.Read());
                            credit.Add(inputBuyAmount);
                            expenseOf[credit.gdsType] += inputBuyAmount;
                        }
                        else if (inputBuyGoods == "4")
                        {
                            Console.WriteLine("==> Total biaya yang dikeluarkan?");
                            inputExpense = Convert.ToDouble(Console.Read());
                            expenseOf[lpg.gdsType] += inputExpense;

                            Console.WriteLine("==> Ingin tambah hingga kapasitas maksimum (150 kg atau 50 tabung gas)?)");

                            while (true)
                            {
                                Console.WriteLine("    Pilih y untuk ya dan  t untuk tidak");
                                string inputYes = Console.ReadLine();
                                if (inputYes == "y")
                                {
                                    lpg.Add(lpg.MaxToAdd());
                                    break;
                                }
                                else if (inputYes == "t")
                                {
                                    Console.WriteLine("Jadi, mau menambahkan berapa?");
                                    inputBuyAmount = Convert.ToDouble(Console.Read());
                                    lpg.Add(inputBuyAmount);
                                    break;
                                }
                                else { Console.WriteLine("Pilih y atau t saja"); }
                            }
                        }
                        else { Console.WriteLine("Pilihan tidak ditemukan"); goto BELI; }
                        Console.Clear();
                        Console.WriteLine("Ingin menambahkan stok lagi?(y/t)");
                        while (true)
                        {
                            string inputToAdd = Console.ReadLine();
                            if (inputToAdd == "y") { goto BELI; }
                            else if (inputToAdd == "t") { goto MENU; }
                            else { Console.WriteLine("Pilihan tidak ditemukan!"); }
                        }
                        break;
                    }
                case 5:
                    {
                    JUAL:
                        Console.WriteLine("=====================================================");
                        Console.WriteLine("Berikut adalah item yang ada");
                        for (int i = 0; i < listOfGoods.Count(); i++)
                        {
                            Console.WriteLine($" {i + 1}\t: {listOfGoods[i]}");
                        }
                        Console.WriteLine($" {listOfGoods.Count}\t:  Kembali ke menu utama");
                        Console.WriteLine("=====================================================");
                        Console.WriteLine("==> Barang yang akan dijual? ");
                        string inputSoldGoods = Console.ReadLine();
                        Console.WriteLine("==> Jumlah barang yang akan dijual?");
                        double inputSoldAmount = Convert.ToDouble(Console.Read());

                        if (inputSoldGoods == "1")
                        {
                            Console.WriteLine("Ukuran galon berapa liter?");
                            string liter = Console.ReadLine();
                            rflWater.Sub(inputSoldAmount, liter);   // Mengurangi stok barang
                            revenueOf[rflWater.gdsType] += CalculateIncome.CalculateRevenue(inputSoldAmount, rflWater.priceList[liter]);
                        }
                        else if (inputSoldGoods == "2")
                        {
                            Console.WriteLine("Ukuran madunya yang berapa gram?");
                            string gram = Console.ReadLine();
                            btlHoney.Sub(inputSoldAmount, gram);   // Mengurangi stok barang
                            revenueOf[btlHoney.gdsType] += CalculateIncome.CalculateRevenue(inputSoldAmount, btlHoney.priceList[gram]);
                        }
                        else if (inputSoldGoods == "3")
                        {
                            Console.WriteLine("Pulsanya berapa?");
                            string rupiah = Console.ReadLine();
                            credit.Sub(rupiah);   // Mengurangi stok barang
                            revenueOf[credit.gdsType] += credit.priceList[rupiah];
                        }
                        else if (inputSoldGoods == "4")
                        {
                            Console.WriteLine("Ukuran gas berapa kg?");
                            string kg = Console.ReadLine();
                            lpg.Sub(inputSoldAmount, kg);   // Mengurangi stok barang
                            revenueOf[lpg.gdsType] += CalculateIncome.CalculateRevenue(inputSoldAmount, rflWater.priceList[kg]);
                        }
                        else if (inputSoldGoods == "5")
                        {
                            DaftarMenu();
                        }

                        while (true)
                        {
                            Console.WriteLine("Masih ada barang yang terjual(y/t)?");
                            string n = Console.ReadLine();
                            if (n == "y") { goto JUAL; }
                            else if (n == "n") { goto MENU; }
                            else { Console.WriteLine("Pilihan tidak ditemukan, silakan pilih y atau t"); }
                        }
                    }
                case 6:
                    {
                        apps.Logout();
                        goto LOGIN;
                    }
                default:
                    {
                        Console.WriteLine("\tMaaf, perintah tidak ditemukan.\nMenu hanya terdiri dari 0-5 saja");
                        DaftarMenu();
                    }
            }
        }
    }
}
