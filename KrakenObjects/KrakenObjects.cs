namespace Kraken
{
    /// <summary>
    /// class to hold Open High Low Close Data from Kraken API
    /// </summary>
    public class OHLC
    {
        private int last = 0;
        private TickData[] tickerData = new TickData[0];
        private bool errorState = false;
        private string error = "";

        public int Last { get => last; set => last = value; }
        public TickData[] TickerData { get => tickerData; set => tickerData = value; }
        public bool ErrorState { get => errorState; set => errorState = value; }
        public string Error { get => error; set => error = value; }
    }
    public class TickData
    {
        private int time = 0;
        private string open = "";
        private string high = "";
        private string low = "";
        private string close = "";
        private string vWap = "";
        private string volume = "";
        private int count = 0;
        private string error = "";
        private bool errorState = false;

        public int Time { get => time; set => time = value; }
        public string Open { get => open; set => open = value; }
        public string High { get => high; set => high = value; }
        public string Low { get => low; set => low = value; }
        public string Close { get => close; set => close = value; }
        public string VWap { get => vWap; set => vWap = value; }
        public string Volume { get => volume; set => volume = value; }
        public int Count { get => count; set => count = value; }
        public string Error { get => error; set => error = value; }
        public bool ErrorState { get => errorState; set => errorState = value; }
    }
    /// <summary>
    /// class to hold ticker data from the kraken api
    /// </summary>
    public class Ticker
    {
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
    }
}