using System.Reflection;

namespace BonyadCode.Mapper.AspNetCore;

public static class Mapper
{
    public static T MapTo<T>(this object source)
    {
        ArgumentNullException.ThrowIfNull(source);

        T target;
        try
        {
            target = Activator.CreateInstance<T>();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(
                $"Could not create instance of type '{typeof(T)}'. Ensure it has a public parameterless constructor.",
                ex);
        }

        var sourceProperties = source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var targetProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanWrite)
            .ToDictionary(p => p.Name);

        foreach (var sourceProp in sourceProperties)
        {
            if (!sourceProp.CanRead) continue;

            if (targetProperties.TryGetValue(sourceProp.Name, out var targetProp))
            {
                try
                {
                    var value = sourceProp.GetValue(source);
                    if (value == null) continue;

                    if (targetProp.PropertyType.IsAssignableFrom(sourceProp.PropertyType))
                    {
                        targetProp.SetValue(target, value);
                    }
                    else
                    {
                        var convertedValue = Convert.ChangeType(value, targetProp.PropertyType);
                        targetProp.SetValue(target, convertedValue);
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(
                        $"Failed to map property '{sourceProp.Name}' to '{targetProp.Name}'.", ex);
                }
            }
        }

        return target;
    }
}