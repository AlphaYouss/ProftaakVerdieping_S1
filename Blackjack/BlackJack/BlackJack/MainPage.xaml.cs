using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BlackJack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Speler Speler1 = new Speler();

        public MainPage()
        {
            this.InitializeComponent();

            Kaarten.Text = Speler1.GetKaarten();
            
            Saldo.Text = Convert.ToString(Speler1.GetSaldo());
        }


        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            Speler1.Hit();
            Kaarten.Text = Speler1.GetKaarten();
        }
    }
}
