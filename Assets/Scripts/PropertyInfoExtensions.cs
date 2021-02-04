using System;
using System.Reflection;

public static class PropertyInfoExtensions
{
    public static void SetValue(this PropertyInfo propertyInfo, object obj, object value)
    {
        var convertedValue = Convert.ChangeType(value, propertyInfo.PropertyType);
        propertyInfo.SetValue(obj, convertedValue);
    }

    public static object GetDefaultValue(Type t)
    {
        if (t.IsValueType)
            return Activator.CreateInstance(t);

        return null;
    }
}
