# DiscoveryTemplateService

Este repositório demonstra como implementar Serviços utilizando tipo genérico<T> que compartilham a mesma interface.

```csharp
public abstract class ServiceBase<T> : IService<T> where T : IEntityDomain{}

public class CustomerService : ServiceBase<Customer>{}

public class TelephoneService : ServiceBase<Telephone>{}
```

Realizar a descoberta do Serviço por meio da implementação da interface compartilhada no netcore.
```csharp
var service = serviceProvider.GetService<IService<T>>();
```

## Exemplo

```csharp
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
```
