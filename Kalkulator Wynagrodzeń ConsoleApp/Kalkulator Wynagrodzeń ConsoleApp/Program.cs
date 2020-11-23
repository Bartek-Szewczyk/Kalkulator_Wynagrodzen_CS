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
           

            var praca =new Pit0(new Pracownik());
            praca.Raport();
            
        }
    }
}
