using UnityEngine;
using System.Collections;
[CreateAssetMenu()]
public class PlayerSettings : SavedObject
{
    public int BestCount;

    public void Set(int count)
    {
        if (count > BestCount)
        {
            BestCount = count;
        }
    }
}
