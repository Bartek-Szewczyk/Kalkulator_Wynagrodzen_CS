using System;
using System.Collections.Generic;
using System.Text;

namespace Kalkulator_Wynagrodzeń_ConsoleApp
{
    public interface Kompozyt
    {
        string Nazwa { get; set; }
    }

    public class Lisc : Kompozyt
    {
        public string Nazwa { get; set; }

    }
}
