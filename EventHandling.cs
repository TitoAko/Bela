using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bela
{
    /// <summary>
    /// Contains informations about who's turn it is to play, the one who called, what EPC values are in game and what is suite
    /// </summary>
    public class MyGameDetails
    {
        /// <summary>
        /// Creates main object for handling events and setting up new games, also contains all the informations about
        /// total scores, current game scores, who called suite and EPC's and similar relevant data.
        /// accessible through events.
        /// </summary>
        /// <param name="GameOrder">Shows who got the cards first, 0 = me, 1 = right oponent, 2 = my teammate, 3 = left oponent</param>
        /// <param name="CallColor">Shows what is suite 0 = , 1 = , 2 = , 3 = </param>
        /// <param name="WhoCalled">Shows who selected suite, often varies from GameOrder, 0 = me, 1 = right oponent, 2 = my teammate, 3 = left oponent</param>
        /// <param name="EPCValues">Values determining who called values calls and how much he had, can be from 2 players
        /// (only one team can call at one time)</param>
        public MyGameDetails(int GameOrder, string CallColor, int WhoCalled, List<Players> EPCValues)
        {
            iCardsDealtOrder = GameOrder;
            strSelectedAdut = CallColor;
            iCaller = WhoCalled;
            iEPCValues = EPCValues;
        }

        private int iCardsDealtOrder;
        private string strSelectedAdut;
        private int iCaller;
        private List<Players> iEPCValues;

        public int CardsDealtOrder { get { return iCardsDealtOrder; } }
        public string SelectedAdut { get { return strSelectedAdut; } }
        public int Caller { get { return iCaller; } }
        public List<Players> EPCValues { get { return iEPCValues; } }
    }
}
