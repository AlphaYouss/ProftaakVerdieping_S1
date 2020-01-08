using System.Collections.Generic;

namespace Roulette
{
    class RL_Player
    {
        public List<KeyValuePair<string, int>> bet  { get; private set; } = new List<KeyValuePair<string, int>>();
        public string namePlayer { get; private set; }
        public int balance { get; private set; } = 25000;
        public string placedbet { get; private set; }

        public void PlaceBet(string name, int amount)
        {
            bet.Add(new KeyValuePair<string, int>(name, amount));
            placedbet = name;
            balance = balance - amount;
        }

        public void CancelBet(int amount)
        {
            bet.Clear();
            balance = balance + amount;
        }
    }
}
