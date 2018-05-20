using System;
using System.Collections.Generic;
using System.Drawing;

namespace Bela
{
    /// <summary>
    /// handles individual cards in players hand
    /// </summary>
    public class CardsIndividual : IComparable<CardsIndividual>, IDisposable
    {
        // order of cards: club, diamond, hearts, spades, 7, 8, 9, 10, j, q, k, a
        public CardsIndividual(int cardNumber)
        {
            i_CardNumber = cardNumber;
            b_ThisCardIsFlipped = false;
        }

        private int i_CardNumber;
        private List<string> li_KnowsOfThisCard;
        private bool b_ThisCardIsFlipped;
        private bool b_ThisCardIsKnownToPlayer;

        public bool ThisCardIsFlippedAndKnownToPlayer
        {
            get
            {
                return b_ThisCardIsFlipped;
            }
            set
            {
                b_ThisCardIsFlipped = value;
            }
        }

        // TODO: Replace switch with enumeration
        public string CardName
        {
            get
            {
                switch (i_CardNumber)
                {
                    case 0:
                        return "club7";
                    case 1:
                        return "club8";
                    case 2:
                        return "club9";
                    case 3:
                        return "club10";
                    case 4:
                        return "clubj";
                    case 5:
                        return "clubq";
                    case 6:
                        return "clubk";
                    case 7:
                        return "cluba";
                    case 8:
                        return "diamond7";
                    case 9:
                        return "diamond8";
                    case 10:
                        return "diamond9";
                    case 11:
                        return "diamond10";
                    case 12:
                        return "diamondj";
                    case 13:
                        return "diamondq";
                    case 14:
                        return "diamondk";
                    case 15:
                        return "diamonda";
                    case 16:
                        return "hearts7";
                    case 17:
                        return "hearts8";
                    case 18:
                        return "hearts9";
                    case 19:
                        return "hearts10";
                    case 20:
                        return "heartsj";
                    case 21:
                        return "heartsq";
                    case 22:
                        return "heartsk";
                    case 23:
                        return "heartsa";
                    case 24:
                        return "spades7";
                    case 25:
                        return "spades8";
                    case 26:
                        return "spades9";
                    case 27:
                        return "spades10";
                    case 28:
                        return "spadesj";
                    case 29:
                        return "spadesq";
                    case 30:
                        return "spadesk";
                    case 31:
                        return "spadesa";
                    default:
                        return "Error";
                }
            }
        }

        public Image CardImage
        {
            get
            {
                if (b_ThisCardIsFlipped)
                {
                    switch (i_CardNumber)
                    {
                        case 0:
                            return global::Bela.Properties.Resources.clubs7;
                        case 1:
                            return global::Bela.Properties.Resources.clubs8;
                        case 2:
                            return global::Bela.Properties.Resources.clubs9;
                        case 3:
                            return global::Bela.Properties.Resources.clubs10;
                        case 4:
                            return global::Bela.Properties.Resources.clubsJ;
                        case 5:
                            return global::Bela.Properties.Resources.clubsQ;
                        case 6:
                            return global::Bela.Properties.Resources.clubsK;
                        case 7:
                            return global::Bela.Properties.Resources.clubsA;
                        case 8:
                            return global::Bela.Properties.Resources.diamond7;
                        case 9:
                            return global::Bela.Properties.Resources.diamond8;
                        case 10:
                            return global::Bela.Properties.Resources.diamond9;
                        case 11:
                            return global::Bela.Properties.Resources.diamond10;
                        case 12:
                            return global::Bela.Properties.Resources.diamondJ;
                        case 13:
                            return global::Bela.Properties.Resources.diamondQ;
                        case 14:
                            return global::Bela.Properties.Resources.diamondK;
                        case 15:
                            return global::Bela.Properties.Resources.diamondA;
                        case 16:
                            return global::Bela.Properties.Resources.hearts7;
                        case 17:
                            return global::Bela.Properties.Resources.hearts8;
                        case 18:
                            return global::Bela.Properties.Resources.hearts9;
                        case 19:
                            return global::Bela.Properties.Resources.hearts10;
                        case 20:
                            return global::Bela.Properties.Resources.heartsJ;
                        case 21:
                            return global::Bela.Properties.Resources.heartsQ;
                        case 22:
                            return global::Bela.Properties.Resources.heartsK;
                        case 23:
                            return global::Bela.Properties.Resources.heartsA;
                        case 24:
                            return global::Bela.Properties.Resources.spades7;
                        case 25:
                            return global::Bela.Properties.Resources.spades8;
                        case 26:
                            return global::Bela.Properties.Resources.spades9;
                        case 27:
                            return global::Bela.Properties.Resources.spades10;
                        case 28:
                            return global::Bela.Properties.Resources.spadesJ;
                        case 29:
                            return global::Bela.Properties.Resources.spadesQ;
                        case 30:
                            return global::Bela.Properties.Resources.spadesK;
                        case 31:
                            return global::Bela.Properties.Resources.spadesA;
                        default:
                            throw new CardValueIncorectException();
                    }
                }
                else
                {
                    return global::Bela.Properties.Resources.background;
                }
            }
        }

        public int CardNumber
        {
            get { return i_CardNumber; }
            set { i_CardNumber = value; }
        }

        public int CompareTo(CardsIndividual cardValue)
        {
            return this.i_CardNumber.CompareTo(cardValue.i_CardNumber);
        }

        public void Dispose()
        {
        }

        public enum Hearts
        {
            seven, eight, nine, ten, jack, queen, king, ace
        }
        public enum Spades
        {
            seven, eight, nine, ten, jack, queen, king, ace
        }
        public enum Clubs
        {
            seven, eight, nine, ten, jack, queen, king, ace
        }
        public enum Diamonds
        {
            seven, eight, nine, ten, jack, queen, king, ace
        }
    }
}
