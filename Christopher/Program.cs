using System;
using Kraken;
using KrakenObjects;

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
            TradeAdvice ta = TradeAdvice.Neutral;
            string j = AppSettings.ReadSetting("test");
            Logging.Log(AppSettings.ReadSetting("LOGFILE"), "this is the first log entry", true);
            ta = TechnicalAnalysis.GetRSI();
            object x = new object();
        }

       

        #endregion Private Methods
    }
}