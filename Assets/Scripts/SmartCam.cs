using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SmartCam : MonoBehaviour, IPause
{

    [SerializeField] Transform target;
    new Transform transform;
    [Range(1, 20)] [SerializeField] float Speed = 1;
    bool Pause;
    public void Play()
    {
        Pause = false;

    }

    public void Stop()
    {
        Pause = true;

    }
    private void Awake()
    {
        transform = base.transform;
    }
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if (!Pause)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + new Vector3(0, 2), Time.deltaTime * Speed) + new Vector3(0, 0, -10);
        }
    }
}
