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

namespace Ganzenbord
{
    sealed partial class MainPage : Page
    {
        public Ganzenbord ganzenbord { get; private set; }
        public MainPage(int aantalSpelers)
        {
            this.InitializeComponent();
            ganzenbord = new Ganzenbord(aantalSpelers);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ganzenbord.CheckBeurtOverslaan())
            {
                ganzenbord.VolgendeSpeler();
            }
            else
            {
                ganzenbord.ZetStap();
                ganzenbord.VolgendeSpeler();
            }
        }
    }
}
