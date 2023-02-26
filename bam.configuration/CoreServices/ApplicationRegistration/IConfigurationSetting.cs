namespace Bam.Net.CoreServices.ApplicationRegistration.Data
{
    public interface IConfigurationSetting
    {
        IConfiguration Configuration { get; set; }
        ulong ConfigurationId { get; set; }
        string Key { get; set; }
        string Value { get; set; }
    }
}