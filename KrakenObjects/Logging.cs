﻿using System;
using System.Diagnostics;
using System.IO;

namespace Kraken
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
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    if (timestamp)
                    {
                        writer.WriteLine(DateTime.Now.ToString() + " -- " + message);
                    }
                    else
                    {
                        writer.WriteLine(message);
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
        /// <summary>
        /// Simple logging function to log entries to a text file for debugging 
        /// Since filename is not specificed we call config.logfile and hope its listed in the app.config
        /// </summary>
        /// <param name="message">string of text you want logged</param>
        /// <param name="timestamp">bool indicating if you want the datetime.meow prefixed to the message</param>
        public static void Log(string message, bool timestamp)
        {
            string fileName = Config.Logfile;
            
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    if (timestamp)
                    {
                        writer.WriteLine(DateTime.Now.ToString() + " -- " + message);
                    }
                    else
                    {
                        writer.WriteLine(message);
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