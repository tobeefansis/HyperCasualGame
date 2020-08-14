using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPattern : MonoBehaviour, IPause
{
    public List<GameObject> patternsPrefub = new List<GameObject>();
    public List<Transform> patterns = new List<Transform>();
    public Transform target;
    public float Distance;
    public float Height;
    public int MaxCount;
    public PlayerSettings settings;
    public int Count;
    public Text Score;
    public Text BestScore;
    Transform Last => patterns[patterns.Count - 1];
    bool Pause;



    public void Play()
    {
        Pause = false;

    }

    public void Stop()
    {
        Pause = true;

    }

    void LateUpdate()
    {
        if (!Pause)
        {
            var last = Last;

            if (Last && Vector2.Distance(last.position, target.position) <= Distance)
            {
                var t = Instantiate(patternsPrefub[Random.Range(0, patternsPrefub.Count)], last.position + new Vector3(0, Height, 0), Quaternion.identity, transform);
                if (patterns.Count == MaxCount)
                {
                    Destroy(patterns[0].gameObject);
                    patterns.RemoveAt(0);
                }
                patterns.Add(t.transform);
                Count++;
                Score.text = $"{Count - 1}";
                settings.Set(Count - 1);
                BestScore.text = $"Best {settings.BestCount}";
            }
        }
    }
    void Start()
    {
        BestScore.text = $"Best {settings.BestCount}";
    }
}
