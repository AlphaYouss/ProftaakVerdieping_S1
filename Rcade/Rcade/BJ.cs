namespace Rcade
{
    class BJ
    {
        public BJ_Speler deSpeler { get; private set; } = new BJ_Speler();
        public BJ_Speler deDealer { get; private set; } = new BJ_Speler();
        public BJ_Kaarten bank { get; private set; } = new BJ_Kaarten();

        public string uitkomst { get; private set; } = "";
        public bool gameOver { get; private set; } = false;

        public bool insurance { get; private set; } = false;
        public bool heeftInsurance { get; private set; }
        public bool beurtGedaan { get; private set; } = false;

        private double inzet = 50;
        public double echteInzet { get; private set; } = 50;

        public enum fiches { Fifty = 50, Hundered = 100, Twohundered = 200, Fivehunderd = 500 };

        //Start 
        public void Beurt1(double inzet)
        {
            bool zichtbaar = false;

            deSpeler.PakKaart(bank);
            if (deSpeler.Aas() == true)
            {
                zichtbaar = true;
            }

            deDealer.PakKaart(bank);
            deDealer.DealerAzen();
            if (deDealer.InsuranceControle())
            {
                heeftInsurance = true;
                zichtbaar = true;
            }

            if (!zichtbaar)
            {
                Beurt2(inzet);
            }
        }

        public void Beurt2(double inzet)
        {
            deSpeler.PakKaart(bank);
            deSpeler.Aas();

            deDealer.PakKaart(bank);
            deDealer.DealerAzen();

            if (insurance)
            {
                if (deDealer.spelerKaarten[1].punt == 10)
                {
                    double InsuranceGeld = (inzet / 2) + inzet;

                    deSpeler.SaldoBijschrijven(InsuranceGeld);

                    Stand(inzet, bank);
                }
            }
            beurtGedaan = true;
        }

        //Hit
        public void Hit(double inzet)
        {
            deSpeler.PakKaart(bank);
            SpelerBustControle(inzet);
        }

        public void SpelerBustControle(double Inzet)
        {
            if (deSpeler.TotaalPunten() > 21)
            {
                uitkomst = "Speler bust!";
                gameOver = true;
            }
        }

        //Stand
        public void Stand(double inzet, BJ_Kaarten bank)
        {
            deDealer.HitControle(bank);
            WinnaarControle(inzet);
        }

        public string WinnaarControle(double inzet)
        {
            int Speler = deSpeler.TotaalPunten();
            int Dealer = deDealer.TotaalPunten();

            if (insurance && Dealer == 21)
            {
                uitkomst = "Insurance wordt uitbetaald!";
            }

            else if (Speler == 21)
            {
                uitkomst = "De speler heeft blackjack!";
                deSpeler.SaldoBijschrijven(inzet * 2);
            }

            else if (Dealer > 21)
            {
                uitkomst = "Dealer Bust!";
                deSpeler.SaldoBijschrijven(inzet * 2);
            }


            else if (Speler > Dealer && Speler <= 21)
            {
                uitkomst = "De speler heeft gewonnen!";
                deSpeler.SaldoBijschrijven(inzet * 2);
            }


            else if (Dealer > Speler)
            {
                uitkomst = "De dealer heeft gewonnen!";
            }

            else if (Speler == Dealer)
            {
                uitkomst = "Push. Gelijkspel!";
                deSpeler.SaldoBijschrijven(inzet);
            }
            gameOver = true;
            return uitkomst;
        }

        //Einde
        public void Clear()
        {
            deSpeler.HandLegen();
            deDealer.HandLegen();

            uitkomst = "";

            gameOver = false;
            heeftInsurance = false;
            beurtGedaan = false;

            ResetInzet();
        }

        //Inzet
        public bool InzetCheck(double inzet)
        {
            this.inzet += inzet;

            if (this.inzet > deSpeler.saldo)
            {
                uitkomst = "Je inzet is groter dan je saldo!";
                ResetInzet();

                return false;
            }
            else if (this.inzet > 1000)
            {
                uitkomst = "Je inzet is te hoog (max 1000)";
                this.inzet = echteInzet;

                return false;
            }
            else if (deSpeler.saldo <= 0)
            {
                uitkomst = "Je saldo is negatief..";
                // Hier komt een link naar de back knop
                return false;
            }
            else
            {
                uitkomst = "";
                echteInzet = this.inzet;

                return true;
            }
        }

        // Variabele met een private set aanpassen
        public void ChangeUitkomst(string NieuweUitkomst)
        {
            uitkomst = NieuweUitkomst;
        }

        public void ChangeInsurance(bool Waarde)
        {
            insurance = Waarde;
        }

        public void ChangeBeurtGedaan(bool Waarde)
        {
            beurtGedaan = Waarde;
        }

        public void ResetInzet()
        {
            inzet = 50;
            echteInzet = 50;
        }
    }
}
