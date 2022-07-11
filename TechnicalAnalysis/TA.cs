using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

       
        public static async Task<string> GetHttp(string URL)
        {
            string jsondata = "";

            using (HttpClient client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Clear();
                //client.DefaultRequestHeaders.Add("API-Key", apiPublicKey);
                //client.DefaultRequestHeaders.Add("API-Sign", signature);
                //client.DefaultRequestHeaders.Add("User-Agent", "KrakenDotNet Client");
                StringContent data = new StringContent("", Encoding.UTF8, "application/x-www-form-urlencoded");
                HttpResponseMessage response = await client.PostAsync("deadPeople", data);
                jsondata = response.Content.ReadAsStringAsync().Result;
            }

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