using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SmartCam : MonoBehaviour
{

    [SerializeField] Transform target;
    new Transform transform;
    [Range(1, 20)] [SerializeField] float Speed = 1;

    private void Awake()
    {
        transform = base.transform;
    }
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * Speed) + new Vector3(0, 0, -10);

    }
}
