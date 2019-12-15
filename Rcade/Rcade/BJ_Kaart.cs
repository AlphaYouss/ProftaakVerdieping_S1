namespace Rcade
{
    class BJ_Kaart
    {
        public int punt { get; private set; }
        public string plaatje { get; private set; }

        //Constructor
        public BJ_Kaart(int GegevenPunt, string GegevenKaart)
        {
            punt = GegevenPunt;
            plaatje = GegevenKaart;
        }

        // Voor Aas
        public void ChangeToOne()
        {
            punt = 1;
        }

        public void ChangeToEleven()
        {
            punt = 11;
        }
    }
}
