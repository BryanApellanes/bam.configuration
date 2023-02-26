using System.Collections.Generic;

namespace Bam.Net.CoreServices.ApplicationRegistration.Data
{
    public interface IConfiguration
    {
        IApplication Application { get; set; }
        ulong ApplicationId { get; set; }
        ulong ApplicationKey { get; set; }
        IMachine Machine { get; set; }
        ulong MachineId { get; set; }
        string Name { get; set; }
        List<IConfigurationSetting> Settings { get; set; }
    }
}