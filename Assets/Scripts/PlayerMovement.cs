using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundCheck))]
public class PlayerMovement : MonoBehaviour, IPause
{
    [Range(1, 100)] public float speed = 1;

    public UnityEvent OnDead;
    public UnityEvent OnDamaged;

    bool isPause = false;
    bool isGround = false;
    Rigidbody2D _RB;
    GroundCheck groundCheck;
    void Awake()
    {
        _RB = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<GroundCheck>();
    }

    public void Jump()
    {
        if (groundCheck.IsGround)
        {
            transform.parent = null;
            _RB.AddForce(Vector2.up * speed*10);
        }
        else
        {

        }
    }


    public void Play()
    {
        isPause = false;
        _RB.WakeUp();
    }

    public void Stop()
    {
        isPause = true;
        _RB.Sleep();
    }
}
