namespace Bela
{
    public static class MyConstants
    {
        public enum GameStatus
        {
            GameInitialized, GameStartNoSuit, GameStartedClubMe, GameStartedClubRight, GameStartedClubMyPartner, GameStartedClubLeft, GameStartedDiamondMe, GameStartedDiamondRight, GameStartedDiamondMyPartner, GameStartedDiamondLeft, GameStartedHeartsMe, GameStartedHeartsRight, GameStartedHeartsMyPartner, GameStartedHeartsLeft, GameStartedSpadesMe, GameStartedSpadesRight, GameStartedSpadesMyPartner, GameStartedSpadesLeft
        }
        public static short NumberOfCardsInHand = 8;
        public static short NumberOfCardsInHandOpen = 6;
        public static short NumberOfCardsInHandHidden = 2;
        public static short NumberOfCardsInDeck = 32;
    }
}
