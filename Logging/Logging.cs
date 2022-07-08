using System.Diagnostics;

namespace Logging
{
    public class Log
    {
        public void WriteToEventLog(string sLog, string sSource, string message, EventLogEntryType level)
        {
            if (!EventLog.SourceExists(sSource)) EventLog.CreateEventSource(sSource, sLog);

            EventLog.WriteEntry(sSource, message, level);
        }
    }
}