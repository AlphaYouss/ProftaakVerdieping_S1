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
        List<Image> vakimages = new List<Image> { };
        public Ganzenbord ganzenbord { get; private set; }
        public MainPage(int aantalSpelers)
        {

            this.InitializeComponent();
            ganzenbord = new Ganzenbord(aantalSpelers, vakimages);
            VulImages();
        }

        private void VulImages()
        {
            vakimages.Add(vak0);
            vakimages.Add(vak1);
            vakimages.Add(vak2);
            vakimages.Add(vak3);
            vakimages.Add(vak4);
            vakimages.Add(vak5);
            vakimages.Add(vak6);
            vakimages.Add(vak7);
            vakimages.Add(vak8);
            vakimages.Add(vak9);
            vakimages.Add(vak10);

            vakimages.Add(vak11);
            vakimages.Add(vak12);
            vakimages.Add(vak13);
            vakimages.Add(vak14);
            vakimages.Add(vak15);
            vakimages.Add(vak16);
            vakimages.Add(vak17);
            vakimages.Add(vak18);
            vakimages.Add(vak19);
            vakimages.Add(vak20);

            vakimages.Add(vak21);
            vakimages.Add(vak22);
            vakimages.Add(vak23);
            vakimages.Add(vak24);
            vakimages.Add(vak25);
            vakimages.Add(vak26);
            vakimages.Add(vak27);
            vakimages.Add(vak28);
            vakimages.Add(vak29);
            vakimages.Add(vak30);

            vakimages.Add(vak31);
            vakimages.Add(vak32);
            vakimages.Add(vak33);
            vakimages.Add(vak34);
            vakimages.Add(vak35);
            vakimages.Add(vak36);
            vakimages.Add(vak37);
            vakimages.Add(vak38);
            vakimages.Add(vak39);
            vakimages.Add(vak40);

            vakimages.Add(vak41);
            vakimages.Add(vak42);
            vakimages.Add(vak43);
            vakimages.Add(vak44);
            vakimages.Add(vak45);
            vakimages.Add(vak46);
            vakimages.Add(vak47);
            vakimages.Add(vak48);
            vakimages.Add(vak49);
            vakimages.Add(vak50);

            vakimages.Add(vak51);
            vakimages.Add(vak52);
            vakimages.Add(vak53);
            vakimages.Add(vak54);
            vakimages.Add(vak55);
            vakimages.Add(vak56);
            vakimages.Add(vak57);
            vakimages.Add(vak58);
            vakimages.Add(vak59);
            vakimages.Add(vak60);

            vakimages.Add(vak61);
            vakimages.Add(vak62);
            vakimages.Add(vak63);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (ganzenbord.CheckBeurtOverslaan() || ganzenbord.CheckInDePut_Gevangenis())
            {
                ganzenbord.ChangeBeurtOverslaan();
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
