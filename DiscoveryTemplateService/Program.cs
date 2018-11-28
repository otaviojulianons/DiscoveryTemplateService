using System;
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

    interface IEntityDomain
    {
        string Id { get; }
    }

    interface IService<T> where T : IEntityDomain
    {
        T Domain { get; set; }
    }

    class Customer : IEntityDomain
    {
        public string Id { get => "customer"; }
    }

    class Telephone : IEntityDomain
    {
        public string Id { get => "telephone"; }
    }

    class CustomerService : ServiceBase<Customer>
    {
        public override Customer Domain { get; set; }
    }

    class TelephoneService : ServiceBase<Telephone>
    {
        public override Telephone Domain { get; set; }
    }

    abstract class ServiceBase<T> : IService<T> where T : IEntityDomain
    {
        public abstract T Domain { get; set; }

        public override string ToString()
        {
            return Domain?.Id ?? "interface";
        }
    }
}
