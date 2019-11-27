using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boter__Kaas_en_Eieren
{
    class BKE
    {
    

        public List<string> ImageBoxen = new List<string>();

        public int aiClick = 0;
        public BKE()
        {
            for (int i = 0; i < 10; i++)
            {
                ImageBoxen.Add("vak" + i);
            }
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
        
        public void PlayerClick(int vak) //toevoegen van een "X" aan de list.
        {
            ImageBoxen[vak] = "X";
        }
        
        public int GenereerNummer() //een nummer tussen 0 en 10 genereren.
        {
            Random rnd = new Random();
            int vak = rnd.Next(1, 10);
            return vak;
        }

        public void AIclick() //checken todat je een nummer rolt dat nog niet in de list is gebruikt.
        {
            bool check = true;
            int i = 0;
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
                i++;
                if (i == 20)
                {
                    break;
                }
            } while (check == true);
        }

        public void clear()
        {
            ImageBoxen.Clear();
             for (int i = 0; i < 10; i++)
            {
                ImageBoxen.Add("vak" + i);
            }
        }
    }
}
