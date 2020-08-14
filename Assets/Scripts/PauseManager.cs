using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Main { get; private set; }

    public bool isPause = false;
    public UnityEvent OnEnd;
    public UnityEvent OnStop;
    public UnityEvent OnPlay;

    private void Awake()
    {
        if (Main == null)
        {
            Main = this;
        }
        else
        {
            Destroy(this);
        }
    }

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

    private void Start()
    {
        Stop();
    }

    public void End()
    {
        Stop();
        OnEnd.Invoke();
    }

    public void Play()
    {
        isPause = false;
        List<IPause> Pauses = new List<IPause>();
        Pauses.AddRange(FindObjectsOfType<Component>().Where(c => c is IPause).Select(c => (IPause)c));
        Pauses.ForEach(n => n.Play());
        OnPlay.Invoke();
    }

    public void Stop()
    {
        isPause = true;
        List<IPause> Pauses = new List<IPause>();

        Pauses.AddRange(FindObjectsOfType<Component>().Where(c => c is IPause).Select(c => (IPause)c));
        Pauses.ForEach(n => n.Stop());
        OnStop.Invoke();
    }

}

public interface IPause
{
    void Play();
    void Stop();
}