using System;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kraken
{

    /// <summary>
    /// Perform Technical Analysis On Kraken Crypto Exchange
    /// MACD https://api.coin-ta.com/macd?key=lpeiMu4nO3xvSk1&backtracks=5&exchange=kraken&symbol=xbtusdt&interval=15m&fastPeriod=12&slowPeriod=26&signalPeriod=9
    /// RSI https://api.coin-ta.com/rsi?key=lpeiMu4nO3xvSk1&backtracks=15&exchange=kraken&symbol=xbtusd&interval=15m
    /// OHLC Data https://api.kraken.com/0/public/OHLC?pair=XBTUSD (gives volume +- as well as last three candle sticks)
    /// </summary>
    public static class TechnicalAnalysis
    {
        public static string GetRSI()
        {
            
        }
        public static string GetPriceAccelDecel()
        {

        }

        public static string GetVolumeChange()
        {

        }

        public static string GetHttp()
        {
            using (HttpClient client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Clear();
                //client.DefaultRequestHeaders.Add("API-Key", apiPublicKey);
                //client.DefaultRequestHeaders.Add("API-Sign", signature);
                //client.DefaultRequestHeaders.Add("User-Agent", "KrakenDotNet Client");
                StringContent data = new StringContent(apiPostBodyData, Encoding.UTF8, "application/x-www-form-urlencoded");
                HttpResponseMessage response = await client.PostAsync(apiEndpointFullURL, data);
                jsonData = response.Content.ReadAsStringAsync().Result;
            }

            return jsonData;
        }

    }



}
