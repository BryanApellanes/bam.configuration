namespace Bam.Net.CoreServices.Auth
{
    public interface IAuthProviderInfo
    {
        string AuthorizationEndpoint { get; set; }
        string ClientId { get; set; }
        string ClientSecret { get; set; }
        string ProviderName { get; set; }
    }
}