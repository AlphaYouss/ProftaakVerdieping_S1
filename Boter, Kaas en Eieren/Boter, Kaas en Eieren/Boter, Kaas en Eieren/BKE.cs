using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boter__Kaas_en_Eieren
{
    class BKE
    {
       public List<string> ImageBoxen = new List<string>() {"vak0", "vak1", "vak2", "vak3", "vak4", "vak5", "vak6", "vak7", "vak8", "vak9" }; //Vakken van het bord.
                                                                                                                                              // "0" is geen vak, maar maakt het aanroepen van elementen overzichtelijker.

        public int aiClick = 0;
        public BKE()
        {
           
        }

        public bool Checken() // Checken of iemand heeft gewonnen
        {
            if  (  //horizontaal  
                   ImageBoxen[1] == ImageBoxen[2] && ImageBoxen[2] == ImageBoxen[3] 
                || ImageBoxen[4] == ImageBoxen[5] && ImageBoxen[5] == ImageBoxen[6]
                || ImageBoxen[7] == ImageBoxen[8] && ImageBoxen[8] == ImageBoxen[9]

                   //verticaal
                || ImageBoxen[1] == ImageBoxen[4] && ImageBoxen[4] == ImageBoxen[7] 
                || ImageBoxen[2] == ImageBoxen[5] && ImageBoxen[5] == ImageBoxen[8]
                || ImageBoxen[3] == ImageBoxen[6] && ImageBoxen[6] == ImageBoxen[9]

                   //diagonaal
                || ImageBoxen[1] == ImageBoxen[5] && ImageBoxen[5] == ImageBoxen[9] 
                || ImageBoxen[3] == ImageBoxen[5] && ImageBoxen[5] == ImageBoxen[7]
                )
            {
                return true;
            }
            return false;
        }
        
        public void PlayerClick(int vak)
        {
            ImageBoxen[vak] = "X";
        }
        
        public int GenereerNummer()
        {
            Random rnd = new Random();
            int vak = rnd.Next(1, 10);
            return vak;
        }

        public void AIclick()
        {
            bool check = true;

            do
            {
                int getal = GenereerNummer();

                if (ImageBoxen[getal] == "X" || ImageBoxen[getal] == "O")
                {

                }
                else
                {
                    ImageBoxen[getal] = "O";
                    aiClick = getal;

                    check = false;
                }

            } while (check == true);
        }
    }
}
