/*
	Copyright © Bryan Apellanes 2015  
*/

namespace Bam.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConfigurer
    {
        /// <summary>
        /// Configures the specified configurable.
        /// </summary>
        /// <param name="configurable">The configurable.</param>
        void Configure(IConfigurable configurable);
    }
}
