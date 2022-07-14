namespace Kraken
{
    /// <summary>
    /// class to hold ticker data from the kraken api
    /// </summary>
    public class Ticker
    {
        #region Private Fields

        //Ask [<price>, <whole lot volume>, <lot volume>]
        private string[] ask = new string[3];

        //XBTUSD, ETHUSD, etc
        private string assetPair = "";

        //Bid [<price>, <whole lot volume>, <lot volume>]
        private string[] bid = new string[3];

        //if errors occurred store them here
        private string[] errors = new string[10];

        //set to true if error <> null
        private bool errorState = false;

        //High [<today>, <last 24 hours>]
        private string[] high = new string[2];

        //Last trade closed [<price>, <lot volume>]
        private string[] lastTradeClosed = new string[2];

        //Low [<today>, <last 24 hours>]
        private string[] low = new string[2];

        //Number of trades [<today>, <last 24 hours>]
        private int[] numberOfTrades = new int[2];

        //Today open price
        private string open = "";

        //Volume [<today>, <last 24 hours>]
        private string[] volume = new string[2];

        //Volume weighted average price [<today>, <last 24 hours>]
        private string[] volumeWeightedAveragePrice = new string[2];

        #endregion Private Fields

        #region Public Constructors

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

        #endregion Public Constructors

        #region Public Properties

        public string[] Ask { get => ask; set => ask = value; }
        public string AssetPair { get => assetPair; set => assetPair = value; }
        public string[] Bid { get => bid; set => bid = value; }
        public string[] Errors { get => errors; set => errors = value; }
        public bool ErrorState { get => errorState; set => errorState = value; }
        public string[] High { get => high; set => high = value; }
        public string[] LastTradeClosed { get => lastTradeClosed; set => lastTradeClosed = value; }
        public string[] Low { get => low; set => low = value; }
        public int[] NumberOfTrades { get => numberOfTrades; set => numberOfTrades = value; }
        public string Open { get => open; set => open = value; }
        public string[] Volume { get => volume; set => volume = value; }
        public string[] VolumeWeightedAveragePrice { get => volumeWeightedAveragePrice; set => volumeWeightedAveragePrice = value; }

        #endregion Public Properties
    }
}