using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PauseManager : MonoBehaviour
{
    public bool isPause = false;
    public void Toggle()
    {
        isPause = !isPause;
        if (!isPause)
        {
            Play();
        }
        else
        {
            Stop();
        }
    }

    public void Play()
    {
        isPause = false;
        List<IPause> Pauses = new List<IPause>();
        Pauses.AddRange(FindObjectsOfType<Component>().Where(c => c is IPause).Select(c => (IPause)c));
        Pauses.ForEach(n => n.Play());
    }

    public void Stop()
    {
        isPause = true;
        List<IPause> Pauses = new List<IPause>();

        Pauses.AddRange(FindObjectsOfType<Component>().Where(c => c is IPause).Select(c => (IPause)c));
        Pauses.ForEach(n => n.Stop());
    }

}

public interface IPause
{
    void Play();
    void Stop();
}