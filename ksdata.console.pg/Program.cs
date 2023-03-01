using ksdata.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddDbContext<KsUserContextPg>(options => 
           options.UseNpgsql(@"Host=localhost;Username=kore;Password=kraken;Database=kraken_dev")
        );
    })
    .Build();

Console.WriteLine("Hello, World!");

var context = host.Services.GetService<KsUserContextPg>();

await host.RunAsync();

Console.WriteLine("Context created");

//
