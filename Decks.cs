using System;
using System.Collections.Generic;
using System.Linq;

namespace Bela
{
    /// <summary>
    /// 8 dealt cards in each player's hand. Initially 6 cards are visible and 2 are covered, when suit is called 2 cards are revealed.
    /// </summary>
    public class Decks
    {
        public Decks()
        {
            //rnd = new Random();
        }

        private void InitializeMainDeck()
        {
            lca_ThisCardsDealt = new List<CardsIndividual>();
            var tmpAllCardValues = DealCards();
            // TODO: Fill decks of each player here...
        }
        /// <summary>
        /// Generates list of 32 numbers from 0 to 31 in random order
        /// </summary>
        /// <returns></returns>
        private List<int> DealCards()
        {
            Random rnd = new Random();
            List<int> tmpAllCardValues = new List<int>();
            // create 32 random card numbers
            for (int i = 0; i < 32; i++)
            {
                short tmp = (short)rnd.Next(32);
                if (tmpAllCardValues.Contains(tmp))
                {
                    tmp = -1;
                    do
                    {
                        tmp += 1;
                    }
                    while (tmpAllCardValues.Contains(tmp));
                }

                tmpAllCardValues.Add(tmp);
            }
            return tmpAllCardValues;
        }
        /// <summary>
        /// Generates list of 32 random numbers
        /// </summary>
        /// <returns>32 numbers from 0 to 31 in random order</returns>
        private List<int> GenerateRandom()
        {
            List<int> tmpRandomList32Numbers = new List<int>();

            return tmpRandomList32Numbers;
        }
        private List<CardsIndividual> lca_ThisCardsDealt;
        private List<CardsIndividual> lca_RightCards;
        private List<CardsIndividual> lca_MyTeammateCards;
        private List<CardsIndividual> lca_LeftCards;
        public List<CardsIndividual> ThisMainDeck
        {
            get
            {
                return lca_ThisCardsDealt;
            }
        }

        public bool ThisDeckIsFull()
        {
            return (lca_ThisCardsDealt.Count > 0);
        }

        //private List<short> i_AllCards, i_MeDeck, i_MeTalon,
        //    i_MyTeammateDeck, i_MyTeammateTalon,
        //    i_LeftOponentDeck, i_LeftOponentTalon,
        //    i_RightOponentDeck, i_RightOponentTalon;

        //public Players pl_Me, pl_MyTeammate, pl_LeftOponent, pl_RightOponent;

        #region Deal Cards
        //private void InitializeDecks()
        //{
        //    i_AllCards = new List<short>(32);
        //    i_MeDeck = new List<short>(6);
        //    i_MeTalon = new List<short>(2);
        //    i_MyTeammateDeck = new List<short>(6);
        //    i_MyTeammateTalon = new List<short>(2);
        //    i_LeftOponentDeck = new List<short>(6);
        //    i_LeftOponentTalon = new List<short>(2);
        //    i_RightOponentDeck = new List<short>(6);
        //    i_RightOponentTalon = new List<short>(2);
        //}
        //private void MixCards()
        //{
        //    InitializeDecks();

        //    // create 32 random card numbers
        //    for (int i = 0; i < 32; i++)
        //    {
        //        short tmp = (short)rnd.Next(0, 31);
        //        if ((tmp > 31) || i_AllCards.Contains(tmp))
        //        {
        //            tmp = -1;
        //            do
        //            {
        //                tmp += 1;
        //            }
        //            while (i_AllCards.Contains(tmp));
        //        }

        //        i_AllCards.Add(tmp);
        //    }
        //    // the deck is now shuffled

        //    i_MeDeck.AddRange(i_AllCards.GetRange(0, 6));
        //    i_MeTalon.AddRange(i_AllCards.GetRange(6, 2));
        //    i_MyTeammateDeck.AddRange(i_AllCards.GetRange(8, 6));
        //    i_MyTeammateTalon.AddRange(i_AllCards.GetRange(14, 2));
        //    i_LeftOponentDeck.AddRange(i_AllCards.GetRange(16, 6));
        //    i_LeftOponentTalon.AddRange(i_AllCards.GetRange(22, 2));
        //    i_RightOponentDeck.AddRange(i_AllCards.GetRange(24, 6));
        //    i_RightOponentTalon.AddRange(i_AllCards.GetRange(30, 2));
        //    // cards are dealt
        //}

        //public List<short> DealCards()
        //{
        //    MixCards();

        //    pl_Me = new Players(i_MeDeck, i_MeTalon, 0);
        //    pl_MyTeammate = new Players(i_MyTeammateDeck, i_MyTeammateTalon, 2);
        //    pl_RightOponent = new Players(i_RightOponentDeck, i_RightOponentTalon, 3);
        //    pl_LeftOponent = new Players(i_LeftOponentDeck, i_LeftOponentTalon, 1);
        //    return pl_Me.DealtCards;
        //}
        #endregion
    }
}
