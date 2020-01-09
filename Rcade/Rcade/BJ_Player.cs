﻿using System;
using System.Collections.Generic;

namespace Rcade
{
    class BJ_Player
    {
        public List<BJ_Card> card { get; private set; } = new List<BJ_Card>();
        public string namePlayer { get; private set; }
        public double balance { get; private set; }
        public double sessionBalance { get; private set; } = 0;
        public int aceLocation { get; private set; }
        public bool hasAce { get; private set; }
        public DateTime lastPlayed { get; private set; }

        public void CheckHit(BJ_Cards cards)
        {
            while (GetTotalPoints() < 17)
            {
                SetCard(cards);
                SetDealerAces();
            }
        }

        public void AddBalance(double stake)
        {
            balance += stake;
            sessionBalance += stake;
        }

        public void DecreaseBalance(double stake)
        {
            balance -= stake;
            sessionBalance -= stake;
        }

        public void Clear()
        {
            card.Clear();
            hasAce = false;
        }

        public bool CheckForAce()
        {
            for (int i = 0; i < card.Count; i++)
            {
                if (card[i].value == 14)
                {
                    aceLocation = i;

                    hasAce = true;
                    return true;
                }
            }
            return false;
        }

        public bool CheckInsurance()
        {
            if (card[0].image.Contains("A"))
            {
                return true;
            }
            return false;
        }

        public bool CheckDoubleDown()
        {
            if (GetTotalPoints() == 9 || GetTotalPoints() == 10 || GetTotalPoints() == 11)
            {
                return true;
            }
            return false;
        }

        public string GetCard(int location)
        {
            return card[location].image;
        }

        public int GetTotalPoints()
        {
            int totalPoints = 0;

            for (int i = 0; i < card.Count; i++)
            {
                totalPoints += card[i].value;
            }
            return totalPoints;
        }

        public void SetPlayerName(string playerName)
        {
            namePlayer = playerName;
        }

        public void SetStats(int balance)
        {
            this.balance = Convert.ToInt32(balance);
            lastPlayed = DateTime.Now;
        }

        public void SetCard(BJ_Cards cards)
        {
            card.Add(cards.NewCard());
        }

        public void SetDealerAces()
        {
            for (int i = 0; i < card.Count; i++)
            {
                if (card[i].value == 14)
                {
                    card[i].SetAceValue(11);
                }
            }
        }

        public void SetHasAce(bool choice)
        {
            hasAce = choice;
        }
    }
}