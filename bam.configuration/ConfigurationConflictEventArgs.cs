namespace Bam.Configuration
{
    public class ConfigurationConflictEventArgs: EventArgs
    {
        public string Key { get; set; } = null!;
        public string WinningValue { get; set; } = null!;
        public string OverriddenValue { get; set; } = null!;
        public Type WinningConfigurationServiceType { get; set; } = null!;
        public Type OverriddenConfigurationServiceType { get; set; } = null!;
    }
}
