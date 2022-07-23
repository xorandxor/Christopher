﻿using System;
using System.Threading.Tasks;

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

        private string apiPrivateKey = "YOUR_PRIVATE_KEY";
        private string apiPublicKey = "YOUR_PUBLIC_KEY";
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

        public Order()
        { }

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
            bool error = false;
            string errormessage = "";

            string privateEndpoint = "AddOrder";

            string p = "";
            //"pair=xdgeur&type=sell&ordertype=limit&volume=3000&price=%2b10.0%"; //Positive Percentage Example (%2 represtes +, which is a reseved character in HTTP)

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
                errormessage += "[price not specified] ";
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
                p += "pair=" + Pair + "&";
                p += "price=" + this.Price + "&";
                p += "volume=" + this.Volume + "&";
                p += "type=" + this.Type.ToString() + "&";
                p += "ordertype=" + this.OrderType.ToString() + "&";

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
                }


            }



        }
        public async Task<bool> AddOrder()
        {
            bool result = false;

            string privateEndpoint = "AddOrder";
            string privateInputParameters = "pair=xdgeur&type=sell&ordertype=limit&volume=3000&price=%2b10.0%"; //Positive Percentage Example (%2 represtes +, which is a reseved character in HTTP)
            string privateResponse = "";

            privateResponse = await API.QueryPrivateEndpoint(privateEndpoint,
                                                                privateInputParameters,
                                                                apiPublicKey,
                                                                apiPrivateKey);
            System.Console.WriteLine(privateResponse);
            return true;
        }

        #endregion Public Methods
    }
}