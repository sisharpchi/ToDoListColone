using ToDoListClone.Bll.Validators;
using FluentValidation;

namespace ToDoListClone.Api.Configurations;

public static class FluentValidatorsDependecyI
{
    public static void AddFluentValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<ToDoItemCreateDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<ToDoItemUpdateDtoValidator>();
    }
}
