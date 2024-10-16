namespace Bam.Configuration
{
    /// <summary>
    /// Resolves the application name from the environment variable named BAM_APPLICATION_NAME 
    /// </summary>
    public class EnvironmentApplicationNameProvider : IApplicationNameProvider
    {
        static EnvironmentApplicationNameProvider _instance;
        public static EnvironmentApplicationNameProvider Instance
        {
            get { return _instance; }
        }
        /// <summary>
        /// Gets the application name from the environment variable
        /// BAM_APPLICATION_NAME or the app setting with the key
        /// ApplicationName if the environment variable is not set.
        /// If neither is set the string "UNKNOWN-APPLICATION" is returned.
        /// </summary>
        /// <returns></returns>
        public string GetApplicationName()
        {
            return BamEnvironmentVariables.ApplicationName();
        }
    }
}