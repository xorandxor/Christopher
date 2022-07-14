using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kraken
{
    /// <summary>
    /// Class to hold configuration data so instead of remembering the key name I can just type config. 
    /// and the list of options pops up with intellisense. 
    /// this clever hack once saved a blind baby from a fire. (true story)
    /// </summary>
    public static class Config
    {
        public static string Logfile => AppSettings.ReadSetting("LOGFILE");
        public static string ApiPrivateKey => AppSettings.ReadSetting("APIPRIVATEKEY");
        public static string ApiPublicKey => AppSettings.ReadSetting("APIPUBLICKEY");
    }
}
