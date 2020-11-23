using System;
using System.Collections.Generic;
using System.Text;

namespace Kalkulator_Wynagrodzeń_ConsoleApp
{
    public interface IUmowa
    {
        void Raport();
       
    }

    public class UmowaOPrace : IUmowa
    {
      
        public void Raport()
        {

            var wyplata = new Wyplata();
            UmowaBuilder umowaBuilder = new Umowa_o_Prace();

            wyplata.ConstructUmowa(umowaBuilder);

            umowaBuilder.Umowa.DisplayConfiguration();
        }

      
    }

    public abstract class Decorator : IUmowa
    {
        IUmowa _umowa;
        

        public Decorator(IUmowa umowa)
        {
            _umowa = umowa;
        }


        public void Raport()
        {
            throw new NotImplementedException();
        }

       
    }


    public class Pit0 : Decorator
    {
        public Pit0(IUmowa umowa) : base(umowa)
        {
            
            var wyplata = new Wyplata();
            UmowaBuilder umowaBuilder = new Umowa_o_Prace();
            umowaBuilder.BuildUbEmerytalne();
            umowaBuilder.BuildUbRentowe();
            umowaBuilder.BuildUbChorobowe();
            umowaBuilder.BuildUbZdrowotne();
            
            umowaBuilder.Umowa.DisplayConfiguration();
            
        }
    }
}
