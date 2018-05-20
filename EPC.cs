using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bela
{
    public class EPC
    {
        public EPC(Players PlayerToCheck)
        {
            List<short> deck = new List<short>{};
            deck.AddRange(PlayerToCheck.DealtCards);
            deck.AddRange(PlayerToCheck.TalonCards);

            ls_allCalls = CallHas20Row(deck);
        }
        /// <summary>
        /// contains all EPCalls for this players deck
        /// </summary>
        private List<short> ls_allCalls;
        /// <summary>
        /// gets all EPCalls for this players deck, values as specified:
        /// -1 = no calls
        /// 0-23 = 20,
        /// 24-43 = 50,
        /// 44-47 = 100 4-of-a-kind,
        /// 48 = 4x9,
        /// 49 = 4xJ
        /// 50-65 = 100 5-in-a-row,
        /// 66-69 = belot
        /// </summary>
        public List<short> AllEpcsForThisPlayer { get { return ls_allCalls; } }
        // order of cards: club, diamond, hearts, spades, 7, 8, 9, 10, j, q, k, a
        // extra points call = epc
        // epc achieved when suite selected, all cards picked, prior to first card played
        // epcs:

        #region 20 in a row, variables: a20Row, dLi_A20Row
        // 20 = 3 cards in a row, {7,8,9}, {8,9,10}, {9,10,j}, {10,j,q}, {j,q,k}, {q,k,a}
        private static List<short> li_20Club789 = new List<short> { 0, 1, 2 },             //  00
            li_20Club8910 = new List<short> { 1, 2, 3 },                            //  01
            li_20Club910J = new List<short> { 2, 3, 4 },                            //  02
            li_20Club10JQ = new List<short> { 3, 4, 5 },                            //  03
            li_20ClubJQK = new List<short> { 4, 5, 6 },                             //  04
            li_20ClubQKA = new List<short> { 5, 6, 7 },                             //  05
            li_20Diamond789 = new List<short> { 8, 9, 10 },                         //  06
            li_20Diamond8910 = new List<short> { 9, 10, 11 },                       //  07
            li_20Diamond910J = new List<short> { 10, 11, 12 },                      //  08
            li_20Diamond10JQ = new List<short> { 11, 12, 13 },                      //  09
            li_20DiamondJQK = new List<short> { 12, 13, 14 },                       //  10
            li_20DiamondQKA = new List<short> { 13, 14, 15 },                       //  11
            li_20Hearts789 = new List<short> { 16, 17, 18 },                        //  12
            li_20Hearts8910 = new List<short> { 17, 18, 19 },                       //  13
            li_20Hearts910J = new List<short> { 18, 19, 20 },                       //  14
            li_20Hearts10JQ = new List<short> { 19, 20, 21 },                       //  15
            li_20HeartsJQK = new List<short> { 20, 21, 22 },                        //  16
            li_20HeartsQKA = new List<short> { 21, 22, 23 },                        //  17
            li_20Spades789 = new List<short> { 24, 25, 26 },                        //  18
            li_20Spades8910 = new List<short> { 25, 26, 27 },                       //  19
            li_20Spades910J = new List<short> { 26, 27, 28 },                       //  20
            li_20Spades10JQ = new List<short> { 27, 28, 29 },                       //  21
            li_20SpadesJQK = new List<short> { 28, 29, 30 },                        //  22
            li_20SpadesQKA = new List<short> { 29, 30, 31 };                        //  23

        // Possible 1 or 2 at once
        // can be combined with 20, 50, 100 row, 100 4 of kind, has no priority, lowest call
        private List<short> a20Row = new List<short> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };

        private List<List<short>> dLi_A20Row = new List<List<short>> {li_20Club789,li_20Club8910,li_20Club910J,li_20Club10JQ,
            li_20ClubJQK, li_20ClubQKA, li_20Diamond789,li_20Diamond8910,li_20Diamond910J,
            li_20Diamond10JQ, li_20DiamondJQK, li_20DiamondQKA,li_20Hearts789,li_20Hearts8910,
            li_20Hearts910J, li_20Hearts10JQ, li_20HeartsJQK,li_20HeartsQKA,li_20Spades789,
            li_20Spades8910,li_20Spades910J,li_20Spades10JQ,li_20SpadesJQK,
            li_20SpadesQKA};

        #endregion
        #region check if there's 20; CallHas20Row
        /// <summary>Check if any deck has 4 in a row, do this after belot check. If belot is present,
        /// return -1, if not, return list with corresponding call values.
        /// Since there's possibility of multiple calls, keep all calls registered
        /// (can be 50 + 4 of a kind, 20 + 50)</summary>
        /// <param name="Deck">input: enter the deck</param>
        /// <returns>-1 if there's no calls or belot is present, 24 - 43 if 50 is present, other values if other calls are present</returns>
        private List<short> CallHas20Row(List<short> Deck)
        {
            // check for belot
            List<short> Call20 = new List<short> { -1 };
            if (CallHasBelot(Deck) > 0)
                return Call20;
            else
            {
                try
                {
                    Call20.AddRange(CallHas50Row(Deck));
                }
                catch { }
                foreach (List<short> call in dLi_A20Row)
                {
                    if (ListIsInList(Deck, call))
                    {
                        Call20.Add(aAll4[dLi_All4.IndexOf(call)]);
                        Call20.Remove(-1);
                    }
                }
            }

            return Call20;
        }
        // Possible 1 or 2 at once, can be different or same color, if 6 in a row, check 100!
        // can be combined with 50 or 100 (both cases), 150, 200, but can't announce 20 in such a case
        #endregion
        
        #region 50 in a row, variables: a50Row, dLi_A50Row
        // 50 = 4 cards in a row, {7,8,9,10}, {8,9,10,j}, {9,10,j,q}, {10,j,q,k},{j,q,k,a}
        private static List<short> li_50Club78910 = new List<short> { 0, 1, 2, 3 },     //  24
            li_50Club8910J = new List<short> { 1, 2, 3, 4 },                            //  25
            li_50Club910JQ = new List<short> { 2, 3, 4, 5 },                            //  26
            li_50Club10JQK = new List<short> { 3, 4, 5, 6 },                            //  27
            li_50ClubJQKA = new List<short> { 4, 5, 6, 7 },                             //  28
            li_50Diamond78910 = new List<short> { 8, 9, 10, 11 },                       //  29
            li_50Diamond8910J = new List<short> { 9, 10, 11, 12 },                      //  30
            li_50Diamond910JQ = new List<short> { 10, 11, 12, 13 },                     //  31
            li_50Diamond10JQK = new List<short> { 11, 12, 13, 14 },                     //  32
            li_50DiamondJQKA = new List<short> { 12, 13, 14, 15 },                      //  33
            li_50Hearts78910 = new List<short> { 16, 17, 18, 19 },                      //  34
            li_50Hearts8910J = new List<short> { 17, 18, 19, 20 },                      //  35
            li_50Hearts910JQ = new List<short> { 18, 19, 20, 21 },                      //  36
            li_50Hearts10JQK = new List<short> { 19, 20, 21, 22 },                      //  37
            li_50HeartsJQKA = new List<short> { 20, 21, 22, 23 },                       //  38
            li_50Spades78910 = new List<short> { 24, 25, 26, 27 },                      //  39
            li_50Spades8910J = new List<short> { 25, 26, 27, 28 },                      //  40
            li_50Spades910JQ = new List<short> { 26, 27, 28, 29 },                      //  41
            li_50Spades10JQK = new List<short> { 27, 28, 29, 30 },                      //  42
            li_50SpadesJQKA = new List<short> { 28, 29, 30, 31 };                       //  43

        // Possible 1 or 2 at once, must be different color, if same color = belot, end match instantly!
        // can be combined with 20, has priority, 100, 150, 200, all 4 same cards case, do not have priority
        private List<short> a50Row = new List<short> { 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43 };

        private List<List<short>> dLi_A50Row = new List<List<short>> {li_50Club78910,li_50Club8910J,li_50Club910JQ,li_50Club10JQK,
            li_50ClubJQKA, li_50Diamond78910, li_50Diamond8910J,li_50Diamond910JQ,li_50Diamond10JQK,
            li_50DiamondJQKA, li_50Hearts78910, li_50Hearts8910J,li_50Hearts910JQ,li_50Hearts10JQK,
            li_50HeartsJQKA, li_50Spades78910, li_50Spades8910J,li_50Spades910JQ,li_50Spades10JQK,
            li_50SpadesJQKA};

        #endregion
        #region check if there's 50; CallHas50Row
        /// <summary>Check if any deck has 4 in a row, do this after belot check. If belot is present,
        /// return -1, if not, return list with corresponding call values.
        /// Since there's possibility of multiple calls, keep all calls registered
        /// (can be 50 + 4 of a kind, 20 + 50)</summary>
        /// <param name="Deck">input: enter the deck</param>
        /// <returns>-1 if there's no calls or belot is present, 24 - 43 if 50 is present, other values if other calls are present</returns>
        private List<short> CallHas50Row(List<short> Deck)
        {
            // check for belot
            List<short> Call50 = new List<short> { -1 };
            if (CallHasBelot(Deck) > 0)
                return Call50;
            else
            {
                try
                {
                    Call50.AddRange(CallHas4Kind(Deck));
                }
                catch { }
                foreach (List<short> call in dLi_A50Row)
                {
                    if (ListIsInList(Deck, call))
                    {
                        Call50.Add(aAll4[dLi_All4.IndexOf(call)]);
                        Call50.Remove(-1);
                    }
                }
            }

            return Call50;
        }
        #endregion

        #region 4 of a kind variables: aAll4, dLi_All4
        // 100 = 4 of a kind, applied for 10, q, k, a, 150 = 4 of a kind, applied for 9, 200 = 4 of a kind, applied for J
        private static List<short> li_100All10 = new List<short> { 3, 11, 19, 27 },     //  44
            li_100AllQ = new List<short> { 5, 13, 21, 29 },                             //  45
            li_100AllK = new List<short> { 6, 14, 22, 30 },                             //  46
            li_100AllA = new List<short> { 7, 15, 23, 31 },                             //  47
            li_150All9 = new List<short> { 2, 10, 18, 26 },                             //  48
            li_200AllJ = new List<short> { 4, 12, 20, 28 };                             //  49
        /// <summary>
        /// list of possible 100 4 of a kind,
        /// 44 = 100 4x10
        /// 45 = 100 4xQ
        /// 46 = 100 4xK
        /// 47 = 100 4xA
        /// 48 = 150 4x9
        /// 49 = 200 4xJ
        /// </summary>
        private List<short> aAll4 = new List<short> { 44, 45, 46, 47, 48, 49 };

        private List<List<short>> dLi_All4 = new List<List<short>> {li_100All10,li_100AllQ,li_100AllK,li_100AllA,
            li_150All9, li_200AllJ};

        #endregion
        #region check if there's 4 of a kind; CallHas4Kind
        // possible 1 or 2 at once
        // can be combined with 20, has priority, 150 has priority over 100, 200 has top priority,
        // all cases can be combined with 20, 50, 100, 150 cases (mixed calls)
        /// <summary>
        /// Check if this deck has 4 of a kind, do this after belot check. If belot is present,
        /// return -1, if not, return list with corresponding call values.
        /// Since there's possibility of multiple calls, keep all calls registered
        /// (can be 100 + 4 of a kind, or 2x20 + 4 of a kind, 50 + 4 of a kind, 4 of a kind + 4 of a kind)
        /// </summary>
        /// <param name="Deck">input: enter the deck</param>
        /// <returns>-1 if there's no calls or belot is present, 44 - 49 if all 4 are present, other values if other calls are present</returns>
        private List<short> CallHas4Kind(List<short> Deck)
        {
            // check for belot
            List<short> Call4OfKind = new List<short> { -1 };
            if (CallHasBelot(Deck) > 0)
                return Call4OfKind;
            else
            {
                try
                {
                    Call4OfKind.AddRange(CallHas100Row(Deck));
                }
                catch{ }
                foreach (List<short> call in dLi_All4)
                {
                    if(ListIsInList(Deck, call))
                    {
                        Call4OfKind.Add(aAll4[dLi_All4.IndexOf(call)]);
                        Call4OfKind.Remove(-1);
                    }
                }
            }

            return Call4OfKind;
        }
        // possible only 1 at once, can be combined with 20 if different color, if not = belot
        #endregion

        #region 100 in a row variables: a100InRow, dLi_100InRow
        // 100 = 5 cards in a row, {7,8,9,10,j}, {8,9,10,j,q}, {9,10,j,q,k}, {10,j,q,k,a}
        private static List<short> li_100Club78910J = new List<short> { 0, 1, 2, 3, 4 },    //  50
            li_100Club8910JQ = new List<short> { 1, 2, 3, 4, 5 },                           //  51
            li_100Club910JQK = new List<short> { 2, 3, 4, 5, 6 },                           //  52
            li_100Club10JQKA = new List<short> { 3, 4, 5, 6, 7 },                           //  53
            li_100Diamond78910J = new List<short> { 8, 9, 10, 11, 12 },                     //  54
            li_100Diamond8910JQ = new List<short> { 9, 10, 11, 12, 13 },                    //  55
            li_100Diamond910JQK = new List<short> { 10, 11, 12, 13, 14 },                   //  56
            li_100Diamond10JQKA = new List<short> { 11, 12, 13, 14, 15 },                   //  57
            li_100Hearts78910J = new List<short> { 16, 17, 18, 19, 20 },                    //  58
            li_100Hearts8910JQ = new List<short> { 17, 18, 19, 20, 21 },                    //  59
            li_100Hearts910JQK = new List<short> { 18, 19, 20, 21, 22 },                    //  60
            li_100Hearts10JQKA = new List<short> { 19, 20, 21, 22, 23 },                    //  61
            li_100Spades78910J = new List<short> { 24, 25, 26, 27, 28 },                    //  62
            li_100Spades8910JQ = new List<short> { 25, 26, 27, 28, 29 },                    //  63
            li_100Spades910JQK = new List<short> { 26, 27, 28, 29, 30 },                    //  64
            li_100Spades10JQKA = new List<short> { 27, 28, 29, 30, 31 };                    //  65
        /// <summary>
        /// list of possible 100 in a row,
        /// 50 - 53 = 100 Club
        /// 54 - 57 = 100 Diamond
        /// 58 - 61 = 100 Hearts
        /// 62 - 65 = 100 Spades
        /// </summary>
        private List<short> a100InRow = new List<short> { 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65 };

        private List<List<short>> dLi_100InRow = new List<List<short>> {li_100Club78910J,li_100Club8910JQ,li_100Club910JQK,li_100Club10JQKA,
            li_100Diamond78910J,li_100Diamond8910JQ,li_100Diamond910JQK,li_100Diamond10JQKA,
            li_100Hearts78910J,li_100Hearts8910JQ,li_100Hearts910JQK,li_100Hearts10JQKA,
            li_100Spades78910J,li_100Spades8910JQ,li_100Spades910JQK,li_100Spades10JQKA};
        #endregion
        #region check if there's 100 in a row; CallHas100Row
        /// <summary>
        /// Check if this deck has 100 in a row, do this after belot check. If belot is present,
        /// return -1, if not, return list with corresponding call values.
        /// Since there's possibility of multiple calls, keep all calls registered
        /// (to avoid confusion for 2x20 in same color = 6 in a row)
        /// </summary>
        /// <param name="Deck">input: enter the deck</param>
        /// <returns>-1 if no call is there, 50-65 if any player has it.</returns>
        private List<short> CallHas100Row(List<short> Deck)
        {
            List<short> Has100Row = new List<short> {-1};
            // check for belot
            short HasOtherCalls = CallHasBelot(Deck);
            if (HasOtherCalls > 0)
                return Has100Row;
            else
            {
                foreach (List<short> li100 in dLi_100InRow)
                {
                    if (ListIsInList(Deck, li100))
                    {
                        Has100Row.Add(a100InRow[dLi_100InRow.IndexOf(li100)]);
                        Has100Row.Remove(-1);
                    }
                }
            }
            return Has100Row;
        }
        // possible only 1 at once, can be combined with 20 if different color, if not = belot
        #endregion

        #region belot variables: Belots, dLi_Belot
        // 1001 = all of the same color, end match instantly!
        private static List<short> li_BelotClub = new List<short> { 0, 1, 2, 3, 4, 5, 6, 7 },   //  66
            li_BelotDiamond = new List<short> { 8, 9, 10, 11, 12, 13, 14, 15 },                 //  67
            li_BelotHearts = new List<short> { 16, 17, 18, 19, 20, 21, 22, 23 },                //  68
            li_BelotSpades = new List<short> { 24, 25, 26, 27, 28, 29, 30, 31 };                //  69

        /// <summary>
        /// list of possible belots,
        /// 66 = Belot Club
        /// 67 = Belot Diamond
        /// 68 = Belot Hearts
        /// 69 = Belot Spades
        /// </summary>
        private List<short> Belots = new List<short> { 66, 67, 68, 69 };
        private List<List<short>> li_AllBelots = new List<List<short>> {li_BelotClub,
                                                 li_BelotDiamond,
                                                 li_BelotHearts,
                                                 li_BelotSpades };
        #endregion
        #region check if there's belot, return -1 if there's no belot; CallHasBelot
        /// <summary>
        /// Check if any deck has belot, do this prior to any other calls check. If belot is present, return value of which belot is it
        /// </summary>
        /// <param name="Deck">input: enter my deck</param>
        /// <returns>-1 if no belot is there, 66-69 if this player has it</returns>
        private short CallHasBelot(List<short> Deck)
        {
            // check if this deck has belot,
            // return belot number if present, -1 if not

            short HasBelot = -1;
            foreach (List<short> belot in li_AllBelots)
            {
                if (ListIsEqual(Deck, belot) == true)
                {
                    HasBelot = (short)li_AllBelots.IndexOf(belot);
                    ls_allCalls.Add(HasBelot);
                }
            }
            return HasBelot;
        }
        #endregion

        // priority call goes to higher value, then higher top card, then suite, then order after deal

        #region list comparisons: ListIsEqual, ListIsInList
        /// <summary>
        /// Checking if all elements of both lists are equal
        /// </summary>
        /// <param name="First">will be checked one by one element and compared to each element in Second</param>
        /// <param name="Second">will be checked if contains elements from First</param>
        /// <returns>true if both lists have equal number of elements and both have same elements</returns>
        private bool ListIsEqual(List<short> First, List<short> Second)
        {
            short tmpCounter = 0;
            foreach (short listElement in First)
            {
                if (Second.Contains(listElement))
                    tmpCounter += 1;
            }
            if (Second.Count == tmpCounter)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checking if all elements of Second are in First
        /// </summary>
        /// <param name="First">will be checked if contains elements from Second</param>
        /// <param name="Second">will be checked one by one element if it is in First </param>
        /// <returns>true if Second is in First, false if some elements from Second are missing from First</returns>
        private bool ListIsInList(List<short> First, List<short> Second)
        {
            short tmpCounter = 0;
            foreach (short listElement in Second)
            {
                if (First.Contains(listElement))
                    tmpCounter += 1;
            }

            if (Second.Count == tmpCounter)
                return true;
            else
                return false;
        }
        #endregion
    }
}
