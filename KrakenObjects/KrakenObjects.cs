using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kraken
{
    public class Ticker
    {
        public Ticker(){}

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

        //XBTUSD, ETHUSD, etc
        public string AssetPair = "";

        //Ask [<price>, <whole lot volume>, <lot volume>]
        public string[] Ask = new string[3];

        //Bid [<price>, <whole lot volume>, <lot volume>]
        public string[] Bid = new string[3];
        
        //Last trade closed [<price>, <lot volume>]
        public string[] LastTradeClosed = new string[2];
        
        //Volume [<today>, <last 24 hours>]
        public string[] Volume = new string[2];
        
        //Volume weighted average price [<today>, <last 24 hours>]
        public string[] VolumeWeightedAveragePrice = new string[2];
        
        //Number of trades [<today>, <last 24 hours>]
        public int[] NumberOfTrades = new int[2];
        
        //Low [<today>, <last 24 hours>]
        public string[] Low = new string[2];
        
        //High [<today>, <last 24 hours>]
        public string[] High = new string[2];
        
        //Today open price
        public string Open = "";

        //set to true if error <> null
        public bool ErrorState = false;

        //if errors occurred store them here
        public string[] Errors = new string[10];
    
    }


    public class OHLC
    {

    }
}
