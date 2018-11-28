namespace DiscoveryPrototypeService.Interfaces
{
    public interface IService<T> where T : IEntityDomain
    {
        T Domain { get; set; }
    }
}
