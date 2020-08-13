using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SavedController : MonoBehaviour
{
    public static SavedController Main { get; private set; }

    public List<SavedObject> savedObjects = new List<SavedObject>();
   
    private void Awake()
    {
        if (!Main)
        {
            Main = this;
            DontDestroyOnLoad(this);
            Load();
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnDestroy()
    {
        Save();
    }

    public void Save()
    {
        savedObjects.ForEach(n => n.Save());
    }

    public void Load()
    {
        savedObjects.ForEach(n => n.Load());
    }
}
