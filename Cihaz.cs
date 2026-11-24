using System;

public class Cihaz
{
    public int Kimlik { get; private set; }
    public string Ad { get; private set; }
    public CihazTuru Tur { get; private set; }
    public bool AcikMi { get; private set; }

    public Cihaz(int kimlik, string ad, CihazTuru tur)
    {
        Kimlik = kimlik;
        Ad = ad;
        Tur = tur;
        AcikMi = false;
    }

    public void Ac() { AcikMi = true; }
    public void Kapat() { AcikMi = false; }

    public void BilgileriGoster()
    {
        Console.WriteLine($"Kimlik: {Kimlik}");
        Console.WriteLine($"Ad: {Ad}");
        Console.WriteLine($"Tur: {Tur}");
        Console.WriteLine($"Durum: {(AcikMi ? "Acik" : "Kapali")}");
        Console.WriteLine("--------------------");
    }
}
