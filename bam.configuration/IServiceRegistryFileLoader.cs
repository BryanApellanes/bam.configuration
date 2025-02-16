using Bam.DependencyInjection;
using Bam.Services;

namespace Bam.Configuration
{
    public interface IServiceRegistryFileLoader
    {
        string[] SearchAssemblies { get; }
        ServiceRegistry LoadServiceRegistry(string path);
    }
}
