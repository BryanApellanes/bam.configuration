using System.Collections.Generic;

namespace Bam.CoreServices.ApplicationRegistration.Data
{
    public interface IUser
    {
        string Email { get; set; }
        List<IOrganization> Organizations { get; set; }
        ISubscription[] Subscriptions { get; set; }
        string UserName { get; set; }
    }
}