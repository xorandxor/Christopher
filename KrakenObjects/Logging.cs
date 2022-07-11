using System;
using System.Diagnostics;
using System.IO;

namespace KrakenObjects
{
    public static class Logging
    {
        #region Public Methods

        /// <summary>
        /// Simple logging function to log entries to a text file for debugging 
        /// </summary>
        /// <param name="file">c:\users\bob\mylog.log</param>
        /// <param name="message">string of text you want logged</param>
        public static void Log(string file, string message, bool timestamp)
        {
            string fileName = file;
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    if(timestamp)
                    {
                        writer.Write(DateTime.Now.ToString() + " -- " + message);
                    }
                    else
                    {
                        writer.Write(message);
                    }
                    writer.Close();
                    writer.Dispose();
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }

        }
        public static void WriteToEventLog(string sLog, string sSource, string message, EventLogEntryType level)
        {
            if (!EventLog.SourceExists(sSource)) EventLog.CreateEventSource(sSource, sLog);

            EventLog.WriteEntry(sSource, message, level);
        }

        #endregion Public Methods
    }
}