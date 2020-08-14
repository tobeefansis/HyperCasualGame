using UnityEngine;
using System.Collections;

public class DeadLine : MonoBehaviour, IPause
{
    [SerializeField] Transform target;
    [Range(0.001f, 10)] [SerializeField] float Speed;
    [Range(0, 100)] [SerializeField] float MaxDistance;
    bool Pause;
    public void Play()
    {
        Pause = false;

    }

    public void Stop()
    {
        Pause = true;

    }

    private void LateUpdate()
    {
        if (!Pause)
        {
            if (Vector3.Distance(transform.position, target.position) < MaxDistance)
            {
                transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * Speed);
            }
            else
            {
                transform.position = target.position - new Vector3(0, MaxDistance, 0);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Pause)
        {
            if (collision.gameObject.tag == "Player")
            {
                var player = collision.gameObject.GetComponent<PlayerMovement>();
                player.Dead();
            }
        }
    }
}
