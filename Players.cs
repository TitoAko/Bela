using System.Collections.Generic;

namespace Bela
{
    public class Players
    {
        /// <summary>
        /// Set who get which cards, and with whom he's playing
        /// Note: setting up calls for this player to no calls initialy
        /// </summary>
        /// <param name="dealtCards">6 cards in total</param>
        /// <param name="talon">2 cards, revealed when suite called</param>
        /// <param name="allegiance">0 = me, 1 = left, 2 = teammate, 3 = right</param>
        public Players(List<short> dealtCards, List<short> talon, short allegiance)
        {
            DealtCards = dealtCards;
            li_TalonCards = talon;
            SortDealtCards();
            s_ThisPlayer = allegiance;
            if ((allegiance % 2) == 0)
                b_Allegiance = true;
            else
                b_Allegiance = false;
        }

        /// <summary>
        /// 6 cards dealt to this player, calling suite from those cards
        /// </summary>
        private List<short> li_DealtCards = new List<short>(6);
        /// <summary>
        /// 6 cards dealt to this player, calling suite from those cards
        /// </summary>
        public List<short> DealtCards
        {
            get { return li_DealtCards; }
            set { li_DealtCards.AddRange(value); }
        }
        /// <summary>
        /// 2 cards dealt to this player, after suite is set, those are revealed
        /// </summary>
        private List<short> li_TalonCards = new List<short>(2);
        /// <summary>
        /// 2 cards dealt to this player, after suite is set, those are revealed
        /// </summary>
        public List<short> TalonCards
        {
            get { return li_TalonCards; }
            set { li_TalonCards.AddRange(value); }
        }
        /// <summary>
        /// True if allegiance is my team, false if it's opponents
        /// </summary>
        private bool b_Allegiance;
        /// <summary>
        /// True if allegiance is my team, false if it's opponents
        /// </summary>
        public bool Allegiance { get { return b_Allegiance; } }
        /// <summary>
        /// used foc checking if player has any EPCalls
        /// </summary>
        private EPC EPCCalls;
        public EPC CallsForThisPlayer { get { return EPCCalls; } }
        /// <summary>
        /// true if this player called suite, false if someone else did
        /// </summary>
        public bool DidICall { get; set; }
        /// <summary>
        /// who is this player
        /// </summary>
        private short s_ThisPlayer;
        public string PlayerName
        {
            get
            {
                switch (s_ThisPlayer)
                {
                    case 0:
                        return "Ja";
                    case 1:
                        return "Lijevi";
                    case 2:
                        return "Moj suigrač";
                    case 3:
                        return "Desni";
                    default:
                        return "Greška!";
                }
            }
        }

        private void SortDealtCards()
        {
            li_DealtCards.Sort();
            li_TalonCards.Sort();
        }
    }
}
