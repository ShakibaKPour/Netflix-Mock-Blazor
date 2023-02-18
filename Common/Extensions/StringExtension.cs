﻿namespace Common.Extensions;

public static class StringExtension
{
    public static string Truncate(this string value, int length)
    {
        if (string.IsNullOrEmpty(value)) return string.Empty;
        if (value.Length >= length) return value;
        var result=  value.Substring(0, length);
        return $"{result}...";
    }
}
