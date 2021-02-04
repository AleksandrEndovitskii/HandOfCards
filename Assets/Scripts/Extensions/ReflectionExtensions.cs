using System;

public static class ReflectionExtensions
{
    public static string GetCallerName([System.Runtime.CompilerServices.CallerMemberName] String propertyName = "")
    {
        return propertyName;
    }
}
