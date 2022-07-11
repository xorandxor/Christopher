namespace KrakenObjects
{
    /// <summary>
    /// class to hold Open High Low Close Data from Kraken API
    /// </summary>
    public class OHLC
    {
        #region Private Fields

        private string error = "";
        private bool errorState = false;
        private int last = 0;
        private TickData[] tickerData = new TickData[0];

        #endregion Private Fields

        #region Public Properties

        public string Error { get => error; set => error = value; }
        public bool ErrorState { get => errorState; set => errorState = value; }
        public int Last { get => last; set => last = value; }
        public TickData[] TickerData { get => tickerData; set => tickerData = value; }

        #endregion Public Properties
    }

    /// <summary>
    /// class to hold OHLC tick data from Kraken API
    /// </summary>
    public class TickData
    {
        #region Private Fields

        private string close = "";
        private int count = 0;
        private string error = "";
        private bool errorState = false;
        private string high = "";
        private string low = "";
        private string open = "";
        private int time = 0;
        private string volume = "";
        private string vWap = "";

        #endregion Private Fields

        #region Public Properties

        public string Close { get => close; set => close = value; }
        public int Count { get => count; set => count = value; }
        public string Error { get => error; set => error = value; }
        public bool ErrorState { get => errorState; set => errorState = value; }
        public string High { get => high; set => high = value; }
        public string Low { get => low; set => low = value; }
        public string Open { get => open; set => open = value; }
        public int Time { get => time; set => time = value; }
        public string Volume { get => volume; set => volume = value; }
        public string VWap { get => vWap; set => vWap = value; }

        #endregion Public Properties
    }
}