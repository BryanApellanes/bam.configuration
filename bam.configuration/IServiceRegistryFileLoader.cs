using Bam.CoreServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Configuration
{
    public interface IServiceRegistryFileLoader
    {
        string[] SearchAssemblies { get; }
        ServiceRegistry LoadServiceRegistry(string path);
    }
}
