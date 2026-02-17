namespace Bam.Configuration
{
    public partial class ConfigurationResolver
    {
        static object _currentLock = new object();
        static ConfigurationResolver _current = null!;
        public static ConfigurationResolver Current
        {
            get
            {
                return _currentLock.DoubleCheckLock(ref _current, () => new ConfigurationResolver());
            }
            set
            {
                _current = value;
            }
        }
        // TODO: add configurationService
    }
}
