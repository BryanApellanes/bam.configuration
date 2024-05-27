namespace Bam.CoreServices.ApplicationRegistration.Data
{
    public interface IClient
    {
        IApplication Application { get; set; }
        ulong ApplicationId { get; set; }
        ulong ApplicationKey { get; set; }
        string ApplicationName { get; set; }
        IMachine Machine { get; set; }
        ulong MachineId { get; set; }
        string MachineName { get; set; }
        int Port { get; set; }
        string Secret { get; set; }
        string ServerHost { get; set; }

        string GetPseudoEmail();
    }
}