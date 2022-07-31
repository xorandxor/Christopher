namespace Kraken
{
    /// <summary>
    /// class to hold ticker data from the kraken api
    /// </summary>
    public class Ticker
    {
        #region Private Fields

        //Ask [<price>, <whole lot volume>, <lot volume>]
        private string ask = "";

        //XBTUSD, ETHUSD, etc
        private string assetPair = "";

        //Bid [<price>, <whole lot volume>, <lot volume>]
        private string bid = "";

        //if errors occurred store them here
        private string errors = "";

        //set to true if error <> null
        private bool errorState = false;

        //High [<today>, <last 24 hours>]
        private string high = "";

        //Last trade closed [<price>, <lot volume>]
        private string lastTradeClosed = "";

        //Low [<today>, <last 24 hours>]
        private string low = "";

        //Number of trades [<today>, <last 24 hours>]
        private int numberOfTrades = 0;

        //Today open price
        private string open = "";

        //Volume [<today>, <last 24 hours>]
        private string volume = "";

        //Volume weighted average price [<today>, <last 24 hours>]
        private string volumeWeightedAveragePrice = "";

        #endregion Private Fields

        #region Public Constructors

        public Ticker()
        { }

        public Ticker(
            string pAssetPair,
            string pAsk,
            string pBid,
            string pLastTradeClosed,
            string pVolume,
            string pVWAvgPrice,
            int pNumTrades,
            string pLow,
            string pHigh,
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

        public string Ask { get => ask; set => ask = value; }
        public string AssetPair { get => assetPair; set => assetPair = value; }
        public string Bid { get => bid; set => bid = value; }
        public bool ErrorState { get => errorState; set => errorState = value; }
        public string High { get => high; set => high = value; }
        public string LastTradeClosed { get => lastTradeClosed; set => lastTradeClosed = value; }
        public string Low { get => low; set => low = value; }
        public int NumberOfTrades { get => numberOfTrades; set => numberOfTrades = value; }
        public string Open { get => open; set => open = value; }
        public string Volume { get => volume; set => volume = value; }
        public string VolumeWeightedAveragePrice { get => volumeWeightedAveragePrice; set => volumeWeightedAveragePrice = value; }

        #endregion Public Properties

        public string GetTicker(string pairname)
        {
            //string publicEndpoint = "Ticker";
            //string publicInputParameters = "pair=ethusd";
            string publicEndpoint = "Ticker";
            string publicInputParameters = "pair="+pairname;

            string publicResponse = API.QueryPublicEndpoint(publicEndpoint, publicInputParameters);
            //{"error":[],"result":{"XXBTZUSD":
            //{
            //"a":["23731.00000","12","12.000"],
            //"b":["23730.90000","1","1.000"],
            //"c":["23731.00000","0.00092706"],
            //"v":["54.24884298","3240.46413440"],
            //"p":["23667.89187","24161.88026"],
            //"t":[745,25366],
            //"l":["23550.10000","23525.60000"],
            //"h":["23768.50000","24699.80000"],
            //"o":"23646.50000"}}}
            string o = publicResponse;
            o = o.Substring(o.IndexOf("\"a\"") +6, o.Length - o.IndexOf("\"a\"") - 6);
            this.ask = o.Substring(0, o.IndexOf('"'));
 
            //23742.60000","1","1.000"],"b":["23738.60000","1","1.000"],"c":["23742.60000","0.01900800"],"v":["61.53560757","3247.10552904"],"p":["23674.07059","24160.93489"],"t":[916,25498],"l":["23550.10000","23525.60000"],"h":["23768.50000","24699.80000"],"o":"23646.50000"}}}
            o=o.Substring(o.IndexOf("],\"b\":[\"") +8,o.Length - o.IndexOf("],\"b\":[\"") - 8);

            //23742.70000","1","1.000"],"c":["23735.20000","0.00027223"],"v":["63.46579718","3241.98181239"],"p":["23676.56864","24161.15251"],"t":[1035,25493],"l":["23550.10000","23525.60000"],"h":["23768.50000","24699.80000"],"o":"23646.50000"}}}
            this.bid = o.Substring(0, o.IndexOf('"'));

            o = o.Substring(o.IndexOf("[\"") + 2, o.Length - o.IndexOf("[\"") - 2);
            //23718.50000","0.38212767"],"v":["64.02659097","3241.33993113"],"p":["23676.98857","24161.16129"],"t":[1057,25493],"l":["23550.10000","23525.60000"],"h":["23768.50000","24699.80000"],"o":"23646.50000"}}}

            Logging.Log(publicResponse);
            System.Console.WriteLine(publicResponse);
           
            return publicResponse;
        }

    }
}