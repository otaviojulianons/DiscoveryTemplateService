using DiscoveryPrototypeService.Interfaces;

namespace DiscoveryPrototypeService.Services
{
    public abstract class ServiceBase<T> : IService<T> where T : IEntityDomain
    {
        public abstract T Domain { get; set; }

        public override string ToString()
        {
            return Domain?.Id ?? "abstract";
        }
    }
}
