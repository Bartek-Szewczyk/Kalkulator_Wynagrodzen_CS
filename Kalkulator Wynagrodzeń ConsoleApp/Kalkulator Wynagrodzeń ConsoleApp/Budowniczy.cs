using System;
using System.Collections.Generic;
using System.Text;

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
            Wynagrodzenie = Program.kwBrutto;
            WyBrutto = Program.kwBrutto;
        }
        public void DisplayConfiguration()
        {
            Console.WriteLine("Umowa: " + _rodzaj);
            Console.WriteLine("Ubezpiecznie Emerytalne: " + Math.Round(UbEmerytalne,2) + " zł");
            Console.WriteLine("Ubezpiecznie Rentowe: " + Math.Round(UbRentowe,2) + " zł");
            Console.WriteLine("Ubezpiecznie Chorobowe: " + Math.Round(UbChorobowe,2) + " zł");
            Console.WriteLine("Ubezpiecznie Zdrowotne: " + Math.Round(UbZdrowotne,2) + " zł");
            Console.WriteLine("Podatek Dochodowy: " + Math.Round(PoDochodowy,2) + " zł");
            Console.WriteLine("Wynarodznie netto: " + Math.Round(Wynagrodzenie,2) + "zł");
        }
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

    public abstract class UmowaBuilder
    {
        public Umowa Umowa { get; set; }
        public abstract void BuildUbEmerytalne();
        public abstract void BuildUbRentowe();
        public abstract void BuildUbChorobowe();
        public abstract void BuildUbZdrowotne();
        public abstract void BuildPoDochodowy();
    }

    public class Umowa_o_Prace : UmowaBuilder
    {
        public Umowa_o_Prace()
        {
            Umowa = new Umowa("Umowa o Pracę");
        }
        public override void BuildUbEmerytalne()
        {
            Umowa.UbEmerytalne = Umowa.WyBrutto * 0.0976;
           
            Umowa.Wynagrodzenie -= Umowa.UbEmerytalne;
        }

        public override void BuildUbRentowe()
        {
            Umowa.UbRentowe = Umowa.WyBrutto * 0.015;
            
            Umowa.Wynagrodzenie -= Umowa.UbRentowe;
        }

        public override void BuildUbChorobowe()
        {
            Umowa.UbChorobowe = Umowa.WyBrutto * 0.0245;
            
            Umowa.Wynagrodzenie -= Umowa.UbChorobowe;
        }

        public override void BuildUbZdrowotne()
        {
            Umowa.UbZdrowotne = Umowa.Wynagrodzenie * 0.09;

            Umowa.Wynagrodzenie -= Umowa.UbZdrowotne;
        }

        public override void BuildPoDochodowy()
        {
            Umowa.PoDochodowy = Umowa.WyBrutto - 250 - Umowa.UbEmerytalne - Umowa.UbChorobowe - Umowa.UbRentowe;
            if (Umowa.WyBrutto * 12 < 85528)
            {
                Umowa.PoDochodowy *= 0.17;
            }
            else
            {
                Umowa.PoDochodowy *= 0.32;
            }
            Umowa.PoDochodowy -= 43.76;
            Umowa.PoDochodowy -=(Umowa.Wynagrodzenie +Umowa.UbZdrowotne) * 0.0775;
            Umowa.Wynagrodzenie -= Umowa.PoDochodowy;
        }
    }
}
