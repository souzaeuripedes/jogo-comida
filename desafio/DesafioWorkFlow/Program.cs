using Microsoft.Extensions.DependencyInjection;

namespace DesafioWorkFlow;

public class Program
{
    public static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddScoped<IWorkFlow, WorkFlow>()
            .AddScoped<IPratos, Pratos>()
            .BuildServiceProvider();
        using var scope = serviceProvider.CreateScope();
        var workFlow = scope.ServiceProvider.GetRequiredService<IWorkFlow>();
        workFlow.ExecutarWorkFlow();
    }
}