using Bam.Net.Data.Repositories;
using System.Collections.Generic;

namespace Bam.Net.CoreServices.ApplicationRegistration.Data
{
    public interface IMachine
    {
        List<IApplication> Applications { get; set; }
        List<IClient> Clients { get; set; }
        List<IConfiguration> Configurations { get; set; }
        string DnsName { get; set; }
        List<IHostAddress> HostAddresses { get; set; }
        string Name { get; set; }
        List<INic> NetworkInterfaces { get; set; }
        List<IProcessDescriptor> Processes { get; set; }

        string GetFirstMac();
        IRepoData Save(IRepository repo);
        string ToJson();
    }
}