using System;

namespace Kraken
{
    /// <summary>
    /// Self explanatory
    /// </summary>
    public enum BuyOrSellType
    {
        NotSet = 0,
        Buy = 1,
        Sell = 2
    }

    public enum KrakenCloseOrderType
    {
        NotSet = 0,
        Limit = 1,
        StopLoss = 2,
        TakeProfit = 3,
        StopLossLimit = 4,
        TakeProfitLimit = 5
    }

    public enum KrakenOrderType
    {
        NotSet = 0,
        Market = 1,
        Limit = 2,
        StopLoss = 3,
        TakeProfit = 4,
        StopLossLimit = 5,
        TakeProfitLimit = 6,
        SettlePosition = 7
    }

    public enum LeverageLevel
    {
        None = 0,
        TwoToOne = 1,
        ThreeToOne = 2,
        FourToOne = 3,
        FiveToOne = 4
    }

    public class Order
    {
        #region Private Fields

        private string apiPrivateKey = Config.ApiPrivateKey;
        private string apiPublicKey = Config.ApiPublicKey;
        private KrakenCloseOrderType closeOrderType = KrakenCloseOrderType.StopLoss;
        private string closePrice = "";
        private String closePrice2 = "";
        private string deadline = "";
        private string expireTime = "";
        private LeverageLevel leverage = LeverageLevel.None;
        private string ofFlags = "";
        private KrakenOrderType orderType = KrakenOrderType.Market;
        private string pair = "";
        private string price = "";
        private string price2 = "";
        private string startTime = "";
        private String stpType = "";
        private string timeInforce = "";
        private BuyOrSellType type = BuyOrSellType.Buy;
        private int userRef = 0;
        private bool validate = false;
        private string volume = "";

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// blank constructor for complex orders 
        /// </summary>
        public Order()
        { }

        /// <summary>
        /// Simple order with no conditional close order
        /// </summary>
        /// <param name="pPair">xbtusd/ethusd</param>
        /// <param name="pBuyOrSell">buy or sell</param>
        /// <param name="pOrderType">market, limit</param>
        /// <param name="pPrice">price in dollars with no dollar sign</param>
        /// <param name="pVolume">volume to be bought or sold</param>
        /// <param name="pLeverage">leverage level requested</param>
        public Order(
            string pPair,
            BuyOrSellType pBuyOrSell,
            KrakenOrderType pOrderType,
            string pPrice,
            string pVolume,
            LeverageLevel pLeverage)
        {
            this.pair = pPair;
            this.type = pBuyOrSell;
            this.orderType = pOrderType;
            this.price = pPrice;
            this.volume = pVolume;
            this.leverage = pLeverage;
        }
        /// <summary>
        /// Simple order with no conditional close order
        /// </summary>
        /// <param name="pPair">xbtusd/ethusd</param>
        /// <param name="pBuyOrSell">buy or sell</param>
        /// <param name="pOrderType">market, limit</param>
        /// <param name="pPrice">price in dollars with no dollar sign</param>
        /// <param name="pVolume">volume to be bought or sold</param>
        /// <param name="pLeverage">leverage level requested</param>
        public Order(
            string pPair,
            BuyOrSellType pBuyOrSell,
            KrakenOrderType pOrderType,
            string pPrice,
            string pVolume,
            LeverageLevel pLeverage,
            KrakenCloseOrderType pCloseOrderType,
            string pClosePrice,
            string PClosePrice2
            )
        {
            this.pair = pPair;
            this.type = pBuyOrSell;
            this.orderType = pOrderType;
            this.price = pPrice;
            this.volume = pVolume;
            this.leverage = pLeverage;
            this.closeOrderType = pCloseOrderType;
            this.closePrice = pClosePrice;
            this.closePrice2 = PClosePrice2;
        }



        #endregion Public Constructors

        #region Public Properties

        public KrakenCloseOrderType CloseOrderType { get => closeOrderType; set => closeOrderType = value; }
        public string ClosePrice { get => closePrice; set => closePrice = value; }
        public string ClosePrice2 { get => closePrice2; set => closePrice2 = value; }
        public string Deadline { get => deadline; set => deadline = value; }
        public string ExpireTime { get => expireTime; set => expireTime = value; }
        public LeverageLevel Leverage { get => leverage; set => leverage = value; }
        public string OfFlags { get => ofFlags; set => ofFlags = value; }
        public KrakenOrderType OrderType { get => orderType; set => orderType = value; }
        public string Pair { get => pair; set => pair = value; }
        public string Price { get => price; set => price = value; }
        public string Price2 { get => price2; set => price2 = value; }
        public string StartTime { get => startTime; set => startTime = value; }
        public string StpType { get => stpType; set => stpType = value; }
        public string TimeInforce { get => timeInforce; set => timeInforce = value; }
        public BuyOrSellType Type { get => type; set => type = value; }
        public int UserRef { get => userRef; set => userRef = value; }
        public bool Validate { get => validate; set => validate = value; }
        public string Volume { get => volume; set => volume = value; }

        #endregion Public Properties

        #region Public Methods

        public string AddOrder()
        {
            //error handling stuff
            bool error = false;
            string errormessage = "";

            // endpoint
            string privateEndpoint = "AddOrder";

            // inpuit parameters
            string privateInputParameters = "";
            //"pair=xdgeur&type=sell&ordertype=limit&volume=3000&price=%2b10.0%"; //Positive Percentage Example (%2 represtes +, which is a reseved character in HTTP)

            //string holding the reply after the order is submitted
            string privateResponse = "";

            // sanity checks
            if (string.IsNullOrEmpty(Volume))
            {
                error = true;
                errormessage += "[Volume not specified] ";
            }
            if (string.IsNullOrEmpty(price))
            {
                error = true;
                errormessage += "[Price not specified] ";
            }
            if (string.IsNullOrEmpty(Pair))
            {
                error = true;
                errormessage += "[Pair not specified] ";
            }
            if (this.OrderType == KrakenOrderType.NotSet)
            {
                error = true;
                errormessage += "[Order type not specified] ";
            }
            if (this.Type == BuyOrSellType.NotSet)
            {
                error = true;
                errormessage += "[BuyOrSell type not specified] ";
            }

            if (error == false)
            {
                privateInputParameters += "pair=" + Pair.ToLower() + "&";
                privateInputParameters += "price=" + this.Price.ToLower() + "&";
                privateInputParameters += "volume=" + this.Volume.ToLower() + "&";
                privateInputParameters += "type=" + this.Type.ToString().ToLower() + "&";
                privateInputParameters += "ordertype=" + this.OrderType.ToString().ToLower() + "&";

                //conditional close order
                if (this.closeOrderType != KrakenCloseOrderType.NotSet)
                {
                    // if close order is specified but price isnt then this will not work
                    if (string.IsNullOrEmpty(this.closePrice))
                    {
                        error = true;
                        errormessage += "[Close order was enabled but close price not specified] ";
                    }

                    //if closing order is specified and price 2 not set then this will cause an error
                    if (string.IsNullOrEmpty(this.closePrice2))
                    {
                        error = true;
                        errormessage += "[Close order was enabled but close price2 not specified] ";
                    }

                    //conditional close order
                    if ((this.closeOrderType != KrakenCloseOrderType.NotSet) & (error == false))
                    {
                        if (this.closeOrderType == KrakenCloseOrderType.StopLoss) { privateInputParameters += "close[stop-loss]" + "&"; }
                        if (this.closeOrderType == KrakenCloseOrderType.StopLossLimit) { privateInputParameters += "close[stop-loss-limit]" + "&"; }
                        if (this.closeOrderType == KrakenCloseOrderType.TakeProfitLimit) { privateInputParameters += "close[take-profit-limit]" + "&"; }
                        if (this.closeOrderType == KrakenCloseOrderType.Limit) { privateInputParameters += "close[limit]" + "&"; }
                        privateInputParameters += "close[price]=" + this.closePrice;
                        privateInputParameters += "close[price2]=" + this.closePrice2;
                    }



                }

                


                privateInputParameters = privateInputParameters.Substring(0,privateInputParameters.Length - 1);

                try
                {
                    Logging.Log(Config.Logfile, "Submitting order with paramneters:[" + privateInputParameters + "]", true);

                    privateResponse = API.QueryPrivateEndpoint(privateEndpoint,
                                                                    privateInputParameters,
                                                                    apiPublicKey,
                                                                    apiPrivateKey);
                }
                catch (Exception e)
                {
                    Logging.Log(Config.Logfile, "error in Order.AddOrder(): " + e.ToString(), true);
                    Console.WriteLine("error in Order.AddOrder(): " + e.ToString());
                }
                Logging.Log(Config.Logfile,"Kraken Response: "+ privateResponse,true);

                System.Console.WriteLine(privateResponse);
            }
            else
            {
                Logging.Log(Config.Logfile, errormessage, true);
            }
            return privateResponse;
        }

        #endregion Public Methods

    }
}