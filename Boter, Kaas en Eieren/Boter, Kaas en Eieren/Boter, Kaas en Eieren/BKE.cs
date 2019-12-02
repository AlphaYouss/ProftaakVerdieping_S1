using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Media.Imaging;

namespace Boter__Kaas_en_Eieren
{
    class BKE
    {
        public Veld veld { get; private set; }
        public BKE(Veld veld)
        {
            this.veld = veld;
        }
        public bool WinCheck()
        {
            if (  
                // Horizontaal.  
                   veld.Velden[1] == veld.Velden[2] && veld.Velden[2] == veld.Velden[3]
                || veld.Velden[4] == veld.Velden[5] && veld.Velden[5] == veld.Velden[6]
                || veld.Velden[7] == veld.Velden[8] && veld.Velden[8] == veld.Velden[9]

                  // Verticaal.
                || veld.Velden[1] == veld.Velden[4] && veld.Velden[4] == veld.Velden[7]
                || veld.Velden[2] == veld.Velden[5] && veld.Velden[5] == veld.Velden[8]
                || veld.Velden[3] == veld.Velden[6] && veld.Velden[6] == veld.Velden[9]

                  // Diagonaal.
                || veld.Velden[1] == veld.Velden[5] && veld.Velden[5] == veld.Velden[9]
                || veld.Velden[3] == veld.Velden[5] && veld.Velden[5] == veld.Velden[7]
                )
            {
                return true;
            }
            return false;
        }
    }
}