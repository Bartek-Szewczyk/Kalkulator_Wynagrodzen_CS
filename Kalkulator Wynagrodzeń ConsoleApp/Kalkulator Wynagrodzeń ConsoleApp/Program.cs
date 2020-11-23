using System;
using System.Security.Cryptography.X509Certificates;

namespace Kalkulator_Wynagrodzeń_ConsoleApp
{
    public class Program
    {
        public static double kwBrutto { get; set; }
        public static void Main(string[] args)
        {
            Console.Write("Podaj Kwotę Brutto: ");
            kwBrutto = Double.Parse(Console.ReadLine());
            Wyplata wyplata = new Wyplata();
            UmowaBuilder umowaBuilder = new Umowa_o_Prace();
            wyplata.ConstructUmowa(umowaBuilder);
            umowaBuilder.Umowa.DisplayConfiguration();

            //Kompozyt korzen = new Wezel();
            //korzen.Nazwa = "Korzeń";
        }
    }
}
