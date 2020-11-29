using System;
using System.Collections.Generic;
using System.Text;
using Kalkulator_Wynarodzen_WPF;


namespace Kalkulator_Wynagrodzeń_ConsoleApp
{
    public class Umowa
    {
        private string _rodzaj;
        public double UbEmerytalne { get; set; }
        public double UbRentowe { get; set; }
        public double UbChorobowe { get; set; }
        public double UbZdrowotne { get; set; }
        public double PoDochodowy { get; set; }
        public double Wynagrodzenie { get; set; }
        public double WyBrutto { get; set; }
        public Umowa(string umowaRodzaj)
        {
            _rodzaj = umowaRodzaj;
            Wynagrodzenie = MainWindow.kwBrutto;
            WyBrutto = MainWindow.kwBrutto;
        }
        public void DisplayConfiguration()
        {
            Console.WriteLine("Umowa: " + _rodzaj);
            Console.WriteLine("Ubezpiecznie Emerytalne: " + Math.Round(UbEmerytalne, 2) + " zł");
            Console.WriteLine("Ubezpiecznie Rentowe: " + Math.Round(UbRentowe, 2) + " zł");
            Console.WriteLine("Ubezpiecznie Chorobowe: " + Math.Round(UbChorobowe, 2) + " zł");
            Console.WriteLine("Ubezpiecznie Zdrowotne: " + Math.Round(UbZdrowotne, 2) + " zł");
            Console.WriteLine("Podatek Dochodowy: " + Math.Round(PoDochodowy, 2) + " zł");
            Console.WriteLine("Wynarodznie netto: " + Math.Round(Wynagrodzenie, 2) + "zł");
        }
    }
    public abstract class UmowaBuilder
    {
        public Umowa Umowa { get; set; }
        public abstract void BuildUbEmerytalne();
        public abstract void BuildUbRentowe();
        public abstract void BuildUbChorobowe();
        public abstract void BuildUbZdrowotne();
        public abstract void BuildPoDochodowy();
    }


    public class Wyplata
    {
        public void ConstructUmowa(UmowaBuilder umowaBuilder)
        {
            umowaBuilder.BuildUbEmerytalne();
            umowaBuilder.BuildUbRentowe();
            umowaBuilder.BuildUbChorobowe();
            umowaBuilder.BuildUbZdrowotne();
            umowaBuilder.BuildPoDochodowy();
        }
    }




}
