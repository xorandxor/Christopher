namespace Kraken
{
    internal class Program
    {
        #region Private Methods

        private static void Main(string[] args)
        {
            string headerline = "";
            headerline += "***********************************************\n";
            headerline += "***--- Christopher Trading System Start  ---***\n";
            headerline += "***********************************************\n";

            Logging.Log(Config.Logfile, headerline, false);

            string j = AppSettings.ReadSetting("test");
            Logging.Log(Config.Logfile, "this is the first log entry", true);
            Ticker t = new Ticker();
     Logging.Log( t.GetTicker("xbtusd"));
            

            //Order o = new Order("xbtusd", BuyOrSellType.Buy, KrakenOrderType.Market, "10000", ".01", LeverageLevel.FiveToOne);
            //o.AddOrder();

            object x = new object();
        }

        #endregion Private Methods
    }
}