namespace Bam.Net.CoreServices.ApplicationRegistration.Data
{
    public interface IHostAddress
    {
        string AddressFamily { get; set; }
        string HostName { get; set; }
        string IpAddress { get; set; }
        IMachine Machine { get; set; }
        ulong MachineId { get; set; }
    }
}