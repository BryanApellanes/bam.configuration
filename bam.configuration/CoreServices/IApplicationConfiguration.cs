using Bam.CoreServices.Configuration;
using System.Collections.Generic;

namespace Bam.CoreServices
{
    public interface IApplicationConfiguration
    {
        SourcedConfigurationSetting this[string key] { get; set; }

        string Name { get; set; }
        List<SourcedConfigurationSetting> Settings { get; set; }

        void Inject();
        Dictionary<string, string> ToDictionary();
        void UnInject();
    }
}