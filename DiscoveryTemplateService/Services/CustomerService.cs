using DiscoveryPrototypeService.Entities;

namespace DiscoveryPrototypeService.Services
{
    public class CustomerService : ServiceBase<Customer>
    {
        public override Customer Domain { get; set; }
    }
}
