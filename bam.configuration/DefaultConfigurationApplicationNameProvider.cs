/*
	Copyright © Bryan Apellanes 2015  
*/

namespace Bam.Configuration
{
    /// <summary>
    /// An ApplicationNameProvider that retrieves the ApplicationName
    /// value from the appSettings section of the default configuration file
    /// </summary>
    public class DefaultConfigurationApplicationNameProvider: IApplicationNameProvider
    {
        static IApplicationNameProvider _instance;
        static object _lock = new object();
        public static IApplicationNameProvider Instance
        {
            get
            {
                return _lock.DoubleCheckLock(ref _instance, () => new DefaultConfigurationApplicationNameProvider());
            }
        }
        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        /// <returns></returns>
        public string GetApplicationName()
        {
            return DefaultConfiguration.GetAppSetting("ApplicationName", ApplicationDiagnosticInfo.UnknownApplication);
        }
    }
}
