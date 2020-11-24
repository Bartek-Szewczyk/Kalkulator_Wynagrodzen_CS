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
            Console.WriteLine();
            Console.WriteLine("Wybierz rodzaj umowy:");
            Console.WriteLine("1 Umowa o pracę");
            Console.WriteLine("2 Umowa zlecenie");
            Console.WriteLine("3 Umowa o dzięło ");
            Console.Write("Podaj numer: ");
            int rodzajUm = Int32.Parse(Console.ReadLine());
            Console.WriteLine();

            if (rodzajUm == 1)
            {
                Console.Write("Czymasz mniej niż 26 lat?(tak/nie): ");
                string odpAge = Console.ReadLine();
                Console.WriteLine();
                if (odpAge == "tak")
                {
                    var wyplata = new Wyplata();
                    UmowaBuilder umowaBuilder = new Umowa_o_Prace();
                    umowaBuilder.BuildUbEmerytalne();
                    umowaBuilder.BuildUbRentowe();
                    umowaBuilder.BuildUbChorobowe();
                    umowaBuilder.BuildUbZdrowotne();
                    umowaBuilder.Umowa.DisplayConfiguration();
                    Console.WriteLine();
                    var pracodawca = new UEmerytalne(new URentowe(new UWypadkowe(new FP(new FGSP(new Pracodawca())))));
                    Console.WriteLine($"Koszty Pracodawcy: {Math.Round(pracodawca.GetKoszty(), 2)} zł");
                    Console.WriteLine($"Zawierają: {pracodawca.GetNazwa()}");
                }
                else
                {
                    var wyplata = new Wyplata();
                    UmowaBuilder umowaBuilder = new Umowa_o_Prace();
                    wyplata.ConstructUmowa(umowaBuilder);
                    umowaBuilder.Umowa.DisplayConfiguration();
                    Console.WriteLine();
                    var pracodawca = new UEmerytalne(new URentowe(new UWypadkowe(new FP(new FGSP(new Pracodawca())))));
                    Console.WriteLine($"Koszty Pracodawcy: {Math.Round(pracodawca.GetKoszty(), 2)} zł");
                    Console.WriteLine($"Zawierają: {pracodawca.GetNazwa()}");
                }



            }
            else if (rodzajUm == 2)
            {
                Console.Write("Czymasz mniej niż 26 lat?(tak/nie): ");
                string odpAge = Console.ReadLine();

                if (odpAge == "tak")
                {
                    var wyplata = new Wyplata();
                    UmowaBuilder umowaBuilder = new Umowa_Zlecenie();
                    umowaBuilder.Umowa.DisplayConfiguration();
                    Console.WriteLine();
                    var pracodawca = new Pracodawca();
                    Console.WriteLine($"Koszty Pracodawcy: {Math.Round(pracodawca.GetKoszty(), 2)} zł");
                    Console.WriteLine($"Zawierają: {pracodawca.GetNazwa()}");
                }
                Console.Write("Czy jest to jedyna praca?(tak/nie): ");
                string odp = Console.ReadLine();
                if (odp == "tak")
                {
                    var wyplata = new Wyplata();
                    UmowaBuilder umowaBuilder = new Umowa_Zlecenie();
                    wyplata.ConstructUmowa(umowaBuilder);
                    umowaBuilder.Umowa.DisplayConfiguration();
                    Console.WriteLine();
                    var pracodawca = new UEmerytalne(new URentowe(new UWypadkowe(new FP(new FGSP(new Pracodawca())))));
                    Console.WriteLine($"Koszty Pracodawcy: {Math.Round(pracodawca.GetKoszty(), 2)} zł");
                    Console.WriteLine($"Zawierają: {pracodawca.GetNazwa()}");
                }
                else
                {
                    var wyplata = new Wyplata();
                    UmowaBuilder umowaBuilder = new Umowa_Zlecenie();
                    umowaBuilder.BuildUbZdrowotne();
                    umowaBuilder.BuildPoDochodowy();
                    umowaBuilder.Umowa.DisplayConfiguration();
                    Console.WriteLine();
                    var pracodawca = new Pracodawca();
                    Console.WriteLine($"Koszty Pracodawcy: {Math.Round(pracodawca.GetKoszty(), 2)} zł");
                    Console.WriteLine($"Zawierają: {pracodawca.GetNazwa()}");
                }

            }
            else if (rodzajUm == 3)
            {
                var wyplata = new Wyplata();
                UmowaBuilder umowaBuilder = new Umowa_o_Dzielo();
                wyplata.ConstructUmowa(umowaBuilder);
                umowaBuilder.Umowa.DisplayConfiguration();
                Console.WriteLine();
                var pracodawca = new Pracodawca();
                Console.WriteLine($"Koszty Pracodawcy: {Math.Round(pracodawca.GetKoszty(), 2)} zł");
                Console.WriteLine($"Zawierają: {pracodawca.GetNazwa()}");
            }



        }
    }
}
