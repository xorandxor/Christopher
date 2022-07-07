using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrakenObjects
{
    public class Order
    {
        public Order() { }

        public int UserRef = 0;
        KrakenOrderType OrderType = KrakenOrderType.Market;
        BuyOrSellType Type = BuyOrSellType.Buy;
        string Volume = "";
        string Pair = "";
        string Price = "";
        string Price2 = "";
        LeverageLevel Leverage = LeverageLevel.None;
        String StpType = "";
        string OfFlags = "";
        string TimeInforce = "";
        string StartTime = "";
        string ExpireTime = "";
        KrakenCloseOrderType CloseOrderType = KrakenCloseOrderType.StopLoss;
        string ClosePrice = "";
        String ClosePrice2 = "";
        string Deadline = "";
        bool Validate = false;
    }

    public enum KrakenOrderType
    {
        Market = 0,
        Limit = 1,
        StopLoss = 2,
        TakeProfit = 3,
        StopLossLimit = 4,
        TakeProfitLimit = 5,
        SettlePosition = 6
    }
    public enum BuyOrSellType
    {
        Buy = 0,
        Sell = 1
    }

    public enum LeverageLevel
    {
        None = 0,
        TwoToOne = 1,
        ThreeToOne = 2,
        FourToOne = 3,
        FiveToOne = 4
    }

    public enum KrakenCloseOrderType
    {
        Limit = 0,
        StopLoss = 1,
        TakeProfit = 2,
        StopLossLimit = 3,
        TakeProfitLimit = 4,
    }
}
