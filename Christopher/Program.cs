using System;
using Kraken;
using Kraken;

namespace Kraken
{
    internal class Program
    {
        #region Private Fields

        private static string bitmexKey = "API_KEY";
        private static string bitmexSecret = "API_SECRET";

        #endregion Private Fields

        #region Private Methods

        private static void Main(string[] args)
        {
            string headerline = 
                "*************************************************************************\n";
            headerline +=
                "*** Christopher Trading System Start\n";
            headerline +=
                "*************************************************************************\n";

            Logging.Log(AppSettings.ReadSetting("LOGFILE"), headerline, false);
            TradeAdvice TA_RSI = TradeAdvice.Neutral;
            TradeAdvice TA_MACD = TradeAdvice.Neutral;

            string j = AppSettings.ReadSetting("test");
            Logging.Log(AppSettings.ReadSetting("LOGFILE"), "this is the first log entry", true);
            TA_RSI = TechnicalAnalysis.GetRSI();
            TA_MACD = TechnicalAnalysis.GetMACD();

            object x = new object();
        }

       

        #endregion Private Methods
    }
}