using Microsoft.Win32;
using System;
using System.Collections.Generic;

using System.Text;

public static class RegistryAccess
{
    private static RegistryKey baseRegistryKey = Registry.LocalMachine;

    public static string Read(string subKey, string KeyName, string defaultValue)
    {
        RegistryKey key2 = baseRegistryKey.OpenSubKey(subKey);
        if (key2 == null)
        {
            return defaultValue;
        }
        try
        {
            if (key2.GetValue(KeyName.ToUpper()) != null)
            {
                string value = (string)key2.GetValue(KeyName.ToUpper());
                if (value != string.Empty)
                    return (string)key2.GetValue(KeyName.ToUpper());
                else
                    return defaultValue;
            }
            else
            {
                return defaultValue;
            }
        }
        catch (Exception)
        {
            return defaultValue;
        }
    }
    public static RegistryKey BaseKey
    {
        get
        {
            return baseRegistryKey;
        }
    }
}
