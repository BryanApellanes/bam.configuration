﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Configuration
{
    public class DefaultConfigurationProvider : IConfigurationProvider
    {
        public Dictionary<string, string> GetApplicationConfiguration(string applicationName, string configurationName = "")
        {
            LogWarnings(applicationName, configurationName);
            Dictionary<string, string> result = new Dictionary<string, string>();
            NameValueCollection appSettings = DefaultConfiguration.GetAppSettings();

            foreach (string key in appSettings.Keys)
            {
                result.AddMissing(key, appSettings[key]);
            }
            return result;
        }

        static object _serviceLock = new object();
        static DefaultConfigurationProvider _provider;
        public static DefaultConfigurationProvider Instance
        {
            get
            {
                return _serviceLock.DoubleCheckLock(ref _provider, () => new DefaultConfigurationProvider());
            }
        }

        public void SetApplicationConfiguration(string applicationName, Dictionary<string, string> configuration, string configurationName)
        {
            LogWarnings(applicationName, configurationName);
            DefaultConfiguration.SetAppSettings(configuration);
        }

        private static void LogWarnings(string applicationName, string configurationName)
        {
            string configuredAppName = DefaultConfiguration.GetAppSetting("ApplicationName", string.Empty);
            if (!string.IsNullOrEmpty(configuredAppName) && !applicationName.Equals(configuredAppName))
            {
                Logging.Log.Warn("Specified application name ({0}) didn't match value in default config file: {1}", applicationName, configuredAppName);
            }
            if (!string.IsNullOrEmpty(configurationName))
            {
                Logging.Log.Warn("DefaultConfigurationService disregards confugrationName value: {0}", configurationName);
            }
        }
    }
}
