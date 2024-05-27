using System;

namespace Bam.CoreServices.ApplicationRegistration.Data
{
    public interface ISubscription
    {
        DateTime ExpirationDate { get; set; }
        int MaxApplications { get; set; }
        int MaxOrganizations { get; set; }
        string SubscriptionLevel { get; set; }
        IUser User { get; set; }
        ulong UserId { get; set; }
    }
}