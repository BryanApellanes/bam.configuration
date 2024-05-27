namespace Bam.CoreServices.ApplicationRegistration.Data
{
    public interface IOrganization
    {
        IApplication[] Applications { get; set; }
        string Name { get; set; }
        IUser[] Users { get; set; }
    }
}