using System.Collections.Generic;

namespace Bam.Net.CoreServices.ApplicationRegistration.Data
{
    public interface IHostDomain
    {
        List<IApplication> Applications { get; set; }
        bool Authorized { get; set; }
        string DefaultApplicationName { get; set; }
        string DomainName { get; set; }
        int Port { get; set; }
    }
}