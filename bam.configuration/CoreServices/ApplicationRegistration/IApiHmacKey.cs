using System;

namespace Bam.Net.CoreServices.ApplicationRegistration.Data
{
    public interface IApiHmacKey
    {
        IApplication Application { get; set; }
        ulong ApplicationId { get; set; }
        ulong ApplicationKey { get; set; }
        string ClientIdentifier { get; set; }
        DateTime? Confirmed { get; set; }
        bool Disabled { get; set; }
        string DisabledBy { get; set; }
        string SharedSecret { get; set; }
    }
}