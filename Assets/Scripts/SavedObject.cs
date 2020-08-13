using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public abstract class SavedObject : ScriptableObject
{
    public string path;
    public void Save()
    {
        PlayerPrefs.SetString(path, GetValue());
    }

    public string GetValue()
    {
        return JsonUtility.ToJson(this);
    }

    public void SetValue(string value)
    {
        JsonUtility.FromJsonOverwrite(value, this);
    }

    public void Load()
    {
        var str = PlayerPrefs.GetString(path);
        SetValue(str);
    }
}
