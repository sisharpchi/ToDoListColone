using ToDoListClone.Bll.Services;
using ToDoListClone.Dal;
using ToDoListClone.Repository.Services;

namespace ToDoListClone.Api.Configurations;

public static class DependensInjectionConfiguration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IToDoItemRepository,ToDoItemRepository>();
        services.AddScoped<IToDoItemService, ToDoItemService>();
        services.AddScoped<MainContext>();
    }
}
