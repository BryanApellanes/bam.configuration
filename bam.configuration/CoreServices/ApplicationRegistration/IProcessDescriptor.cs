using System;

namespace Bam.CoreServices.ApplicationRegistration.Data
{
    public interface IProcessDescriptor
    {
        IApplication Application { get; set; }
        long ApplicationId { get; set; }
        string CommandLine { get; set; }
        int? ExitCode { get; set; }
        DateTime ExitTime { get; set; }
        string FilePath { get; set; }
        bool HasExited { get; set; }
        string Hash { get; set; }
        string HashAlgorithm { get; set; }
        string InstanceIdentifier { get; set; }
        IClient LocalClient { get; set; }
        IMachine Machine { get; set; }
        ulong MachineId { get; set; }
        string MachineName { get; set; }
        int ProcessId { get; set; }
        DateTime StartTime { get; set; }
    }
}