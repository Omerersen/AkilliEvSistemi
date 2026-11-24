using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        List<Cihaz> cihazlar = new List<Cihaz>();
        cihazlar.Add(new Cihaz(1, "Salon Lambasi", CihazTuru.Lamba));
        cihazlar.Add(new Cihaz(2, "Salon Klimasi", CihazTuru.Klima));
        cihazlar.Add(new Cihaz(3, "Ev Guvenligi", CihazTuru.GuvenlikSistemi));

        while (true)
        {
            Console.WriteLine("\n--- AKILLI EV SISTEMI ---");
            Console.WriteLine("1 - Cihazlari Listele");
            Console.WriteLine("2 - Yeni Cihaz Ekle");
            Console.WriteLine("3 - Cihaz Ac");
            Console.WriteLine("4 - Cihaz Kapat");
            Console.WriteLine("0 - Cikis");
            Console.Write("Seciminiz: ");
            string? secim = Console.ReadLine();
            switch (secim)
            {
                case "1": CihazlariListele(cihazlar); break;
                case "2": CihazEkle(cihazlar); break;
                case "3": CihazDurumDegistir(cihazlar, true); break;
                case "4": CihazDurumDegistir(cihazlar, false); break;
                case "0":
                case null: return;
                default: Console.WriteLine("Gecersiz secim!"); break;
            }
        }
    }

    static void CihazlariListele(List<Cihaz> cihazlar)
    {
        foreach (Cihaz cihaz in cihazlar)
            cihaz.BilgileriGoster();
    }

    static Cihaz? CihazBul(List<Cihaz> cihazlar, int kimlik)
    {
        foreach (Cihaz cihaz in cihazlar)
        {
            if (cihaz.Kimlik == kimlik)
                return cihaz;
        }
        return null;
    }

    static void CihazEkle(List<Cihaz> cihazlar)
    {
        Console.Write("Cihaz kimligi: ");
        if (!int.TryParse(Console.ReadLine(), out int kimlik))
        {
            Console.WriteLine("Gecersiz kimlik!");
            return;
        }
        if (CihazBul(cihazlar, kimlik) != null)
        {
            Console.WriteLine("Bu kimlige sahip cihaz zaten var!");
            return;
        }
        Console.Write("Cihaz adi: ");
        string? ad = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(ad))
        {
            Console.WriteLine("Gecersiz cihaz adi!");
            return;
        }
        Console.WriteLine("1 - Lamba");
        Console.WriteLine("2 - Klima");
        Console.WriteLine("3 - Guvenlik Sistemi");
        Console.Write("Cihaz turu: ");
        if (!int.TryParse(Console.ReadLine(), out int tur) || tur < 1 || tur > 3)
        {
            Console.WriteLine("Gecersiz cihaz turu!");
            return;
        }
        cihazlar.Add(new Cihaz(kimlik, ad, (CihazTuru)tur));
        Console.WriteLine("Cihaz basariyla eklendi.");
    }

    static void CihazDurumDegistir(List<Cihaz> cihazlar, bool ac)
    {
        Console.Write("Cihaz kimligi: ");
        if (!int.TryParse(Console.ReadLine(), out int kimlik))
        {
            Console.WriteLine("Gecersiz kimlik!");
            return;
        }
        Cihaz? cihaz = CihazBul(cihazlar, kimlik);
        if (cihaz == null)
        {
            Console.WriteLine("Cihaz bulunamadi!");
            return;
        }
        if (ac)
        {
            cihaz.Ac();
            Console.WriteLine("Cihaz acildi.");
        }
        else
        {
            cihaz.Kapat();
            Console.WriteLine("Cihaz kapatildi.");
        }
    }
}
