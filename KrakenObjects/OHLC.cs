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

    /// <summary>
    /// class to hold OHLC tick data from Kraken API
    /// </summary>
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
}