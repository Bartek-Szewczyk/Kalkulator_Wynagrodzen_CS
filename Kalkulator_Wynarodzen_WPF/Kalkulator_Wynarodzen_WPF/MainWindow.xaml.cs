using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kalkulator_Wynagrodzeń_ConsoleApp;


namespace Kalkulator_Wynarodzen_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void brutto_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public static double kwBrutto { get; set; }
        private void oblicz_Click(object sender, RoutedEventArgs e)
        {
            kwBrutto = Double.Parse(brutto.Text);
            var wyplata = new Wyplata();
            UmowaBuilder umowaBuilder = new Umowa_o_Prace();
            wyplata.ConstructUmowa(umowaBuilder);
            netto.Text = Math.Round(umowaBuilder.Umowa.Wynagrodzenie,2).ToString();
            umowaBuilder.Umowa.DisplayConfiguration();
        }
    }
}
