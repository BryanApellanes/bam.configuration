/*
	Copyright © Bryan Apellanes 2015  
*/

namespace Bam.Configuration
{
    /// <summary>
    /// Configures IConfigurables by using DefaultConfiguration
    /// </summary>
    public class DefaultConfigurer: IConfigurer
    {
        public void Configure(IConfigurable configurable)
        {
            DefaultConfiguration.SetProperties(configurable);
            DefaultConfiguration.CheckRequiredProperties(configurable);
        }
    }
}
