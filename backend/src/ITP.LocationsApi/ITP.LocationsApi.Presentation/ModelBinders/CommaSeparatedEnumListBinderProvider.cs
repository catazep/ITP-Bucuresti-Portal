using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ITP.LocationsApi.Presentation.ModelBinders;

public class CommaSeparatedEnumListBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        var type = context.Metadata.ModelType;

        if (!type.IsGenericType)
            return null;

        var args = type.GetGenericArguments();
        if (args.Length != 1)
            return null;

        var itemType = args[0];
        if (!itemType.IsEnum)
            return null;

        // Check if List<TEnum> is assignable to the declared type.
        // Covers List<T>, IList<T>, ICollection<T>, IEnumerable<T>, IReadOnlyList<T>, etc.
        var listType = typeof(List<>).MakeGenericType(itemType);
        if (!type.IsAssignableFrom(listType))
            return null;

        return new CommaSeparatedEnumListBinder(itemType);
    }
}
