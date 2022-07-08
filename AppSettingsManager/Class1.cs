using System;
using System.Configuration;

namespace AppSettingsManager
{
    public class AppSettings
    {
 
            static void Main(string[] args)
            {
                ReadAllSettings();
                ReadSetting("Setting1");
                ReadSetting("NotValid");
                AddUpdateAppSettings("NewSetting", "May 7, 2014");
                AddUpdateAppSettings("Setting1", "May 8, 2014");
                ReadAllSettings();
            }

            static void ReadAllSettings()
            {
                try
                {
                    var appSettings = ConfigurationManager.AppSettings;

                    if (appSettings.Count == 0)
                    {
                        Console.WriteLine("AppSettings is empty.");
                    }
                    else
                    {
                        foreach (var key in appSettings.AllKeys)
                        {
                            Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                        }
                    }
                }
                catch (ConfigurationErrorsException)
                {
                    Console.WriteLine("Error reading app settings");
                }
            }

            public static string ReadSetting(string key)
            {
            string result = "";
                try
                {
                    var appSettings = ConfigurationManager.AppSettings;
                    result = appSettings[key] ?? "Not Found";
                                    }
                catch (ConfigurationErrorsException)
                {
                    Console.WriteLine("Error reading app settings");
                }
            return result;
            }

            static void AddUpdateAppSettings(string key, string value)
            {
                try
                {
                    var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    var settings = configFile.AppSettings.Settings;
                    if (settings[key] == null)
                    {
                        settings.Add(key, value);
                    }
                    else
                    {
                        settings[key].Value = value;
                    }
                    configFile.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                }
                catch (ConfigurationErrorsException)
                {
                    Console.WriteLine("Error writing app settings");
                }
            }
        }
    }


