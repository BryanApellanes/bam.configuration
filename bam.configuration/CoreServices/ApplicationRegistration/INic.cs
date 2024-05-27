namespace Bam.CoreServices.ApplicationRegistration.Data
{
    public interface INic
    {
        string Address { get; set; }
        string AddressFamily { get; set; }
        string MacAddress { get; set; }
        IMachine Machine { get; set; }
        ulong MachineId { get; set; }
    }
}