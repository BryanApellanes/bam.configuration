/*
	Copyright © Bryan Apellanes 2015  
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
