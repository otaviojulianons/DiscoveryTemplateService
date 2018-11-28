using DiscoveryPrototypeService.Entities;

namespace DiscoveryPrototypeService.Services
{
    public class TelephoneService : ServiceBase<Telephone>
    {
        public override Telephone Domain { get; set; }
    }
}
