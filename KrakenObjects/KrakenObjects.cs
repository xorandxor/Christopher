namespace Kraken
{
    public class OHLC
    {
    }

    public class Ticker
    {
        //Ask [<price>, <whole lot volume>, <lot volume>]
        public string[] Ask = new string[3];

        //XBTUSD, ETHUSD, etc
        public string AssetPair = "";

        //Bid [<price>, <whole lot volume>, <lot volume>]
        public string[] Bid = new string[3];

        //if errors occurred store them here
        public string[] Errors = new string[10];

        //set to true if error <> null
        public bool ErrorState = false;

        //High [<today>, <last 24 hours>]
        public string[] High = new string[2];

        //Last trade closed [<price>, <lot volume>]
        public string[] LastTradeClosed = new string[2];

        //Low [<today>, <last 24 hours>]
        public string[] Low = new string[2];

        //Number of trades [<today>, <last 24 hours>]
        public int[] NumberOfTrades = new int[2];

        //Today open price
        public string Open = "";

        //Volume [<today>, <last 24 hours>]
        public string[] Volume = new string[2];

        //Volume weighted average price [<today>, <last 24 hours>]
        public string[] VolumeWeightedAveragePrice = new string[2];

        public Ticker()
        { }

        public Ticker(
            string pAssetPair,
            string[] pAsk,
            string[] pBid,
            string[] pLastTradeClosed,
            string[] pVolume,
            string[] pVWAvgPrice,
            int[] pNumTrades,
            string[] pLow,
            string[] pHigh,
            string pOpen)
        {
            this.Ask = pAsk;
            this.Bid = pBid;
            this.LastTradeClosed = pLastTradeClosed;
            this.Volume = pVolume;
            this.VolumeWeightedAveragePrice = pVWAvgPrice;
            this.NumberOfTrades = pNumTrades;
            this.Low = pLow;
            this.High = pHigh;
            this.Open = pOpen;
        }
    }
}