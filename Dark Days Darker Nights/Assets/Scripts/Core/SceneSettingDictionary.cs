using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[Serializable]
public class SceneSettingDictionary : SerializableDictionary<string, object>
{
    /// <summary>
    /// Fetches the key value as an int
    /// Extention to standard dictionary so this code doesn't get replicated around manually
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public int GetKeyAsInt(string key)
    {
        var result = Convert.ToInt32(this[key]);
        return result;
    }

    /// <summary>
    /// Fetches the key value as a boolean value
    /// Extention to standard dictionary so this code doesn't get replicated around manually
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool GetKeyAsBool(string key)
    {
        var result = Convert.ToBoolean(this[key]);
        return result;
    }

}
