using BitMEX;
using System;

namespace Test
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
            Program p = new Program();
            p.Run(args);
            while (1 == 1)
            {
                System.Threading.Thread.Sleep(1000);
                Console.Write(DateTime.Now.ToString());
            }
        }

        private void Run(string[] args)
        {
            BitMEXApi bitmex = new BitMEXApi(bitmexKey, bitmexSecret);
            // var orderBook = bitmex.GetOrderBook("XBTUSD", 3);
            var orders = bitmex.GetOrders();
            // var orders = bitmex.DeleteOrders();
            Console.WriteLine(orders);
        }

        #endregion Private Methods
    }
}