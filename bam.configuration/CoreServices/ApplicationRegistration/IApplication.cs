using System.Collections.Generic;

namespace Bam.Net.CoreServices.ApplicationRegistration.Data
{
    public interface IApplication
    {
        List<IApiHmacKey> ApiKeys { get; set; }
        List<IClient> Clients { get; set; }
        List<IConfiguration> Configurations { get; set; }
        string Description { get; set; }
        List<IHostDomain> HostDomains { get; set; }
        List<IProcessDescriptor> Instances { get; set; }
        List<IMachine> Machines { get; set; }
        string Name { get; set; }
        IOrganization Organization { get; set; }
        ulong OrganizationId { get; set; }
        ulong OrganizationKey { get; set; }
    }
}