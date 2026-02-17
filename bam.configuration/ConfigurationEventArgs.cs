namespace Bam.Configuration
{
    public class ConfigurationEventArgs: EventArgs
    {
        public string Key { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}
