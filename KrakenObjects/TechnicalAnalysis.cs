using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System;

namespace Kraken
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
            string jsonData = "";
            using (var client = new WebClient())
            {
                string response = client.DownloadString(URL);
                if (!string.IsNullOrEmpty(response)) //http response was not blank
                {
                    jsonData = response.ToString();
                }
                else //http response was blank
                {
                    Logging.Log(AppSettings.ReadSetting("LOGFILE"), "Error: Http response for [" + URL + "] was blank!", true);
                }
            }

            //get round trip time for http request
            double result = Math.Round((double)DateTime.Now.Subtract(start).TotalMilliseconds,2);
            //create log message
            string debugmessage = "http request for [" + URL + "] completed in [" + result.ToString() + " ms.]";
            //log the message to the logfile
            Logging.Log(AppSettings.ReadSetting("LOGFILE"),debugmessage,true);
            
            return jsonData;
        }

        public static TradeAdvice GetPriceAccelDecel()
        {
            TradeAdvice t = TradeAdvice.Neutral;

            return t;
        }
        public static TradeAdvice GetMACD()
        {
            TradeAdvice t = TradeAdvice.Neutral;
            //https://api.coin-ta.com/macd?key=lpeiMu4nO3xvSk1&backtracks=5&exchange=kraken&symbol=xbtusdt&interval=15m&fastPeriod=12&slowPeriod=26&signalPeriod=9
            string jsonData = GetHttp("https://api.coin-ta.com/macd?key=lpeiMu4nO3xvSk1&backtracks=3&exchange=kraken&symbol=xbtusdt&interval=5m&fastPeriod=12&slowPeriod=26&signalPeriod=9");
             /*
              * Looks like:
              * {"currentPrice":21060.00000,"results":[
              * {"valueMACD":28.263115040047711905774130,"valueMACDSignal":45.489743702091277867429857160,"valueMACDHist":-17.226628662043565961655727160,"backtrack":0},
              * {"valueMACD":30.936675033970143645596171,"valueMACDSignal":49.796400867602169357843788950,"valueMACDHist":-18.859725833632025712247617950,"backtrack":1},
              * {"valueMACD":36.943485425718845340487632,"valueMACDSignal":54.511332326010175785905693438,"valueMACDHist":-17.567846900291330445418061438,"backtrack":2}]}
              * 
              * so we wanna create a multidimensional array [i] (3x3) [i][valueMACD][valueMACDSignal][valueMACDHist] of type double and populate the data
              * trim everything before [
              * split remainder by { into three strings
              * split each string by , into four fields (ignore string[3] because its the backtrack number
              * field[0] is macd, field[1] is macdsignal, field[2] is macdhist
              *  loop (for i = 0 to 2)
              *  {
              *  array[i][0] = valuemacd
              *  array[i][1] = valueMACDSignal
              *  array[i][2] = valueMACDHist
              *  }
              *  
              *  create meaning from these numbers 
              *  identify crossover events for buy/sell signals
              *  histogram increasing indicates divergence (buy)
              *  histogram decreasing indicates convergence (sell)
              * */



            return t;
        }

        /// <summary> If RSI > 70 sell | IF RSI < 30 buy | IF RSI 30-70 neutral </summary> 
        /// <returns>TradeAdvice</returns>
        public static TradeAdvice GetRSI()
        {
            TradeAdvice t = TradeAdvice.Neutral;

            string jsonData =  GetHttp("https://api.coin-ta.com/rsi?key=lpeiMu4nO3xvSk1&backtracks=1&exchange=kraken&symbol=xbtusd&interval=5m");

            //looks like:
            //{"currentPrice":21031.70000,"results":[{"value":40.449395411680137062618688420,"backtrack":0}]}
            string _tmp = jsonData;
            double val = 0;
            if (jsonData.Contains("value"))
            {
                _tmp = _tmp.Substring(jsonData.IndexOf("value") + 7, 10);
                val = Convert.ToDouble(_tmp);
                Logging.Log(AppSettings.ReadSetting("LOGFILE"), "RSI value is :" + val.ToString(),true);
            }
            else
            {
                Logging.Log(AppSettings.ReadSetting("LOGFILE"),"Could not parse web response for RSI - response was [" + jsonData + "]",true);
            }
            if(val < 30) //oversold
            {
                t = TradeAdvice.Buy;
            }
            if (val > 30 & val < 70) // golden zone
            {
                t = TradeAdvice.Neutral;
            }
            if (val > 70) //overbought
            {
                t = TradeAdvice.Sell;
            }

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