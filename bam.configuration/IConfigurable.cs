/*
	Copyright © Bryan Apellanes 2015  
*/

namespace Bam.Configuration
{
    /// <summary>
    /// When implemented allows configuration by applying a configuration or specifying a configurer.
    /// </summary>
    /// <seealso cref="Bam.Configuration.IHasRequiredProperties" />
    public interface IConfigurable : IHasRequiredProperties
    {
        void Configure(IConfigurer configurer);
        void Configure(object configuration);
    }
}
