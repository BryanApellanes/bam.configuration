namespace Bam.CoreServices.Configuration
{
    public class SourcedConfigurationSetting
    {
        public SettingSource SettingSource { get; set; }
        public string Key { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}
