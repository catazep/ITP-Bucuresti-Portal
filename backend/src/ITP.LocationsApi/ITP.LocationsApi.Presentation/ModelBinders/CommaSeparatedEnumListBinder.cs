using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ITP.LocationsApi.Presentation.ModelBinders;

public class CommaSeparatedEnumListBinder : IModelBinder
{
    private readonly Type _enumType;

    public CommaSeparatedEnumListBinder(Type enumType)
    {
        _enumType = enumType;
    }

    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

        if (result == ValueProviderResult.None)
        {
            var empty = (System.Collections.IList)Activator.CreateInstance(
                typeof(List<>).MakeGenericType(_enumType))!;
            bindingContext.Result = ModelBindingResult.Success(empty);
            return Task.CompletedTask;
        }

        var list = (System.Collections.IList)Activator.CreateInstance(
            typeof(List<>).MakeGenericType(_enumType))!;

        // Get all values (handles both single and repeated params)
        var values = result.Values;

        foreach (var value in values)
        {
            if (string.IsNullOrWhiteSpace(value))
                continue;

            // Split by comma for comma-separated format
            foreach (var segment in value.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                if (Enum.TryParse(_enumType, segment, ignoreCase: true, out var parsed))
                    list.Add(parsed!);
            }
        }

        bindingContext.Result = ModelBindingResult.Success(list);
        return Task.CompletedTask;
    }
}
