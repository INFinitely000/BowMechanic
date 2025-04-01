using UnityEngine;
using System;

public static class Extentions
{
    public static float AbsMax(float first, float second)
    {
        return Mathf.Abs(first) > Mathf.Abs(second) ? first : second;
    }
    
    public static float AbsMin(float first, float second)
    {
        return Mathf.Abs(first) < Mathf.Abs(second) ? first : second;
    }

    public static void IdentifyType(this string text, out Type type, out object value)
    {
        type = null;
        value = null;

        if (int.TryParse(text, out var intValue))
        {
            value = intValue;
            type = typeof(int);
        }
        else if (float.TryParse(text, out var floatValue))
        {
            value = floatValue;
            type = typeof(float);
        }
        else if (bool.TryParse(text, out var boolValue))
        {
            value = boolValue;
            type = typeof(bool);
        }
        else
        {
            value = text;
            type = typeof(string);
        }
    }
}