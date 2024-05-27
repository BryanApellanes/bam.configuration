namespace Bam.CoreServices.ApplicationRegistration.Data
{
    public interface IActiveApiSigningKeyIndex
    {
        string ApplicationIdentifier { get; set; }
        int Value { get; set; }
    }
}