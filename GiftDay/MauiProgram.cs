using AutoMapper;
using BitOfA.Helper.MVVM;
using GiftDay.Common;
using GiftDay.Domain;
using GiftDay.Persistence;
using GiftDay.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GiftDay;

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        //Register all ViewModels
        var services = builder.Services;

        //add service provider
        services.AddSingleton(sp => sp);

        services.AddViewModels();
        services.AddViews();
        services.AddServiceLayer();

        services.AddTransient<AppShell>();

        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<INavLookupService, NavLookupService>();

        services.AddDataContext();

        services.AddMapper();

        services.AddMediatR(Assembly.GetExecutingAssembly());

        var app = builder.Build();
        var sp = app.Services;

        sp.Install();

        return app;
    }

}
public static class Extensions {
    public static void RegisterAll(this IServiceCollection services, string namespaceToRegister) {
        var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                where t.IsClass && t.Namespace == namespaceToRegister
                select t;
        q.ToList().ForEach(t => services.AddTransient(t));
    }
    public static void AddServiceLayer(this IServiceCollection services) {
        var type = typeof(IService);
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => type.IsAssignableFrom(p));
        foreach (var t in types) {
            if (!t.IsInterface) {
                foreach (var myInter in t.GetInterfaces()) {
                    services.AddTransient(myInter, t);
                }
            }
        }
    }
    public static void AddViews(this IServiceCollection services) {
        services.AddTypes<ContentPage>();
    }
    public static void AddViewModels(this IServiceCollection services) {
        services.AddTypes<IViewModel>();
    }
    public static void AddTypes<T>(this IServiceCollection services) {
        var type = typeof(T);
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => type.IsAssignableFrom(p));
        foreach (var t in types) {
            if (!t.IsInterface && !t.IsAbstract)
                services.AddTransient(t);
        }
    }
    public static void AddMapper(this IServiceCollection services) {
        var mpc = new MapperConfiguration(cfg => {
            cfg.AddProfile<MapperProfile>();
        });
        services.AddSingleton<IMapper>(mpc.CreateMapper());
    }
    public static void AddDataContext(this IServiceCollection services) {
        //Build dbcontext options for IContextFactory usage (to leave consumers up to db lifecycle)
        var optionsBuilder = new DbContextOptionsBuilder<GiftDayContext>();
        optionsBuilder.UseSqlite(GetConnectionString());
        services.AddSingleton<DbContextOptions<GiftDayContext>>(optionsBuilder.Options);

        //Add context using EF Core extensions
        services.AddDbContext<GiftDayContext>(ConfigureDatabase);

    }
    private static void ConfigureDatabase(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite(GetConnectionString());  
    }
    private static string GetConnectionString() {
        return $"Data Source={ FileSystem.AppDataDirectory }\\GiftDayDb.db";
    }
}

public static class Installers {
    public static void Install(this IServiceProvider provider) {

        var context = provider.GetService<GiftDayContext>();
        //context.Database.EnsureDeleted();
        context.Database.Migrate();

        //var navLookup = provider.GetService<INavLookupService>();
        //navLookup.RegisterRoute<AddGiftEventViewModel, AddEventView>();
    }

    public static void RegisterRoute<VM, V>(this INavLookupService navLookup)
        where V : IView<VM>
        where VM : IViewModel {
        navLookup.Register<VM, V>();
        Routing.RegisterRoute(typeof(V).Name, typeof(V));
    }
}
