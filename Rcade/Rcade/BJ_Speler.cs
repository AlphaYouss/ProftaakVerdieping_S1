using System.Collections.Generic;

namespace Rcade
{
    class BJ_Speler
    {
        public List<BJ_Kaart> spelerKaarten { get; private set; } = new List<BJ_Kaart>();
        public double saldo { get; private set; } = 25000;
        public bool heeftAas { get; private set; }
        public int aasPlek { get; private set; }
        public double winstVerlies { get; private set; } = 0;

        //Start
        public void PakKaart(BJ_Kaarten bank)
        {
            spelerKaarten.Add(bank.NieuweKaart());
        }

        public string GetKaart(int i)
        {
            return spelerKaarten[i].plaatje;
        }

        public string GetKaarten()
        {
            string Kaart = "";

            for (int i = 0; i < spelerKaarten.Count; i++)
            {
                Kaart = Kaart + "    " + spelerKaarten[i].plaatje;
            }
            return Kaart;
        }

        //Hit
        public int TotaalPunten()
        {
            int totaal = 0;

            for (int i = 0; i < spelerKaarten.Count; i++)
            {
                totaal += spelerKaarten[i].punt;
            }
            return totaal;
        }

        public void DealerAzen()
        {
            for (int i = 0; i < spelerKaarten.Count; i++)
            {
                if (spelerKaarten[i].punt == 14)
                {
                    spelerKaarten[i].ChangeToEleven();
                }
            }
        }

        //Stand
        public void HitControle(BJ_Kaarten bank)
        {
            while (TotaalPunten() < 17)
            {
                PakKaart(bank);
                DealerAzen();
            }
        }

        public void SaldoBijschrijven(double Inzet)
        {
            saldo += Inzet;
            winstVerlies += Inzet;
        }

        public void SaldoAfschrijven(double Inzet)
        {
            saldo -= Inzet;
            winstVerlies -= Inzet;
        }

        //Einde
        public void VeranderHeeftAas(bool Choice)
        {
            heeftAas = Choice;
        }

        public void HandLegen()
        {
            spelerKaarten.Clear();
            heeftAas = false;
        }

        // Speciale Methodes
        public bool Aas()
        {
            for (int i = 0; i < spelerKaarten.Count; i++)
            {
                if (spelerKaarten[i].punt == 14)
                {
                    aasPlek = i;

                    heeftAas = true;
                    return true;
                }
            }
            return false;
        }

        public bool InsuranceControle()
        {
            if (spelerKaarten[0].plaatje.Contains("A"))
            {
                return true;
            }
            return false;
        }

        public bool DoubleDownControle()
        {
            if (TotaalPunten() == 9 || TotaalPunten() == 10 || TotaalPunten() == 11)
            {
                return true;
            }
            return false;
        }
    }
}
