using Terminal.Gui;
using Microsoft.Extensions.DependencyInjection;
using ConsoleMvvm.Views;
using ConsoleMvvm.ViewModels;
using ConsoleMvvm.Helper;

var Services = ConfigureServices();
Application.Init();
Application.Run(Services.GetRequiredService<MainView>());
Application.Top?.Dispose();
Application.Shutdown();


IServiceProvider ConfigureServices()
{
    var services = new ServiceCollection();
    services.AddTransient<MainView>();
    services.AddTransient<MainViewModel>();
    services.AddTransient<HelloView>();
    services.AddTransient<HelloViewModel>();
    services.AddTransient<CounterView>();
    services.AddTransient<CounterViewModel>();

    services.AddSingleton<RegionManager>();
    return services.BuildServiceProvider();
}