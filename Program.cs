using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriYapilariOdev_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Kullanıcıdan veri al
            Console.Write("Kaç adet veri gireceksiniz? ");
            int n = int.Parse(Console.ReadLine());

            double[] veriler = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{i + 1}. veriyi girin: ");
                veriler[i] = double.Parse(Console.ReadLine());
            }

            // Standart sapmayı hesapla
            double standartSapma = StandartSapmaRekursif(veriler);
            Console.WriteLine($"Standart sapma (rekürsif): {standartSapma}");

            Console.ReadLine();
        }


        // Rekürsif fonksiyon: Verilerin toplamını hesapla
        static double ToplamRecursive(double[] veriler, int n, int index = 0)
        {
            if (index == n)
                return 0;
            return veriler[index] + ToplamRecursive(veriler, n, index + 1);
        }

        // Rekürsif fonksiyon: Her bir verinin kare farkını topla
        static double KarelerFarkiRecursive(double[] veriler, double ortalama, int n, int index = 0)
        {
            if (index == n)
                return 0;
            return Math.Pow(veriler[index] - ortalama, 2) + KarelerFarkiRecursive(veriler, ortalama, n, index + 1);
        }

        static double StandartSapmaRekursif(double[] veriler)
        {
            int n = veriler.Length;
            if (n == 0)
                return 0; // Boş veri için standart sapma hesaplanamaz

            // Ortalama hesapla (rekürsif olarak)
            double toplam = ToplamRecursive(veriler, n);
            double ortalama = toplam / n;

            // Kareler farkını hesapla (rekürsif olarak)
            double karelerFarki = KarelerFarkiRecursive(veriler, ortalama, n);

            // Varyansı ve standart sapmayı hesapla
            double varyans = karelerFarki / n;
            return Math.Sqrt(varyans);
        }

    }
}
