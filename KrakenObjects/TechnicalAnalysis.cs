using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System;

namespace KrakenObjects
{
    public enum TradeAdvice
    {
        Buy = 0,
        Neutral = 1,
        Sell = 2
    }

    /// <summary> Perform Technical Analysis On Kraken Crypto Exchange 
    /// MACD https://api.coin-ta.com/macd?key=lpeiMu4nO3xvSk1&backtracks=5&exchange=kraken&symbol=xbtusdt&interval=15m&fastPeriod=12&slowPeriod=26&signalPeriod=9
    /// RSI  https://api.coin-ta.com/rsi?key=lpeiMu4nO3xvSk1&backtracks=15&exchange=kraken&symbol=xbtusd&interval=15m
    /// OHLC https://api.kraken.com/0/public/OHLC?pair=XBTUSD (gives volume +- as well as last
    /// three candle sticks) </summary>
    public static class TechnicalAnalysis
    {
        #region Public Methods

       
        public static string GetHttp(string URL)
        {
            DateTime start = DateTime.Now;
            string jsondata = "";
            using (var client = new WebClient())
            {
                string response = client.DownloadString(URL);
                if (!string.IsNullOrEmpty(response))
                {
                    jsondata = response.ToString();
                }
            }
            double res = Math.Round((double)DateTime.Now.Subtract(start).TotalMilliseconds,2);
            string debugmessage = "http request for [" + URL + "] completed in " + res.ToString() + " ms.";

            Logging.Log("","",true);
            return jsondata;
        }

        public static TradeAdvice GetPriceAccelDecel()
        {
            TradeAdvice t = TradeAdvice.Neutral;
            
            return t;
        }

        /// <summary> If RSI > 70 sell | IF RSI < 30 buy | IF RSI 30-70 neutral </summary> 
        /// <returns>TradeAdvice</returns>
        public static TradeAdvice GetRSI()
        {
            TradeAdvice t = TradeAdvice.Neutral;

            string jsonData =  GetHttp("https://api.coin-ta.com/rsi?key=lpeiMu4nO3xvSk1&backtracks=1&exchange=kraken&symbol=xbtusd&interval=5m");
            //{"currentPrice":21031.70000,"results":[{"value":40.449395411680137062618688420,"backtrack":0}]}
            //JsonConverter jsonConverter = new ;
            // string x = "";
            // x = jsonConverter.ReadJson(jsonData,String).ToString();

            return t;
        }

        public static TradeAdvice GetVolumeChange()
        {
            TradeAdvice t = TradeAdvice.Neutral;

            return t;
        }

        #endregion Public Methods
    }
}