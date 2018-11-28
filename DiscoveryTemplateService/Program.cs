using System;
using DiscoveryPrototypeService.Entities;
using DiscoveryPrototypeService.Interfaces;
using DiscoveryPrototypeService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace StrategyService
{
    public class Program
    {
        protected static ServiceProvider serviceProvider;

        public static void Main(string[] args)
        {
            serviceProvider = new ServiceCollection()
                .AddSingleton<IService<Telephone>, TelephoneService>()
                .AddSingleton<IService<Customer>, CustomerService>()
                .BuildServiceProvider();

            var customer = new Customer();
            var phone = new Telephone();

            Console.WriteLine(DiscoveryService(customer).ToString());
            Console.WriteLine(DiscoveryService(phone).ToString());

            Console.ReadKey();
        }

        static IService<T> DiscoveryService<T>(T entityDomain)  where T : IEntityDomain
        {
            var service = serviceProvider.GetService<IService<T>>();
            service.Domain = entityDomain;
            return service;
        }
    }
}
