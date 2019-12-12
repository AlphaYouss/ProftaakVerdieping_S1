using System.Collections.Generic;

namespace Rcade
{
    class BKE_Veld
    {
        public List<string> Velden { get; private set; } = new List<string>();

        public void VeldGenereren()
        {
            for (int i = 0; i < 10; i++)
            {
                Velden.Add(i.ToString());
            }
        }

        public void ClearVeld()
        {
            Velden.Clear();
            VeldGenereren();
        }
    }
}
