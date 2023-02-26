using System.Collections.Generic;

namespace Bam.Net.CoreServices.Auth
{
    public interface ISupportedAuthProviders
    {
        IAuthProviderInfo this[string providerName] { get; }

        void AddProvider(IAuthProviderInfo provider);
        IEnumerator<IAuthProviderInfo> GetEnumerator();
        void Load(string filePath);
        void Save(string filePath);
    }
}