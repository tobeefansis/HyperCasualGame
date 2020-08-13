using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System;

public class Platform : MonoBehaviour
{
    [SerializeField] Transform pos1;
    [SerializeField] Transform pos2;
    [SerializeField] Transform target;
    bool movingLeft;
    [Range(0.1f, 3)] [SerializeField] float time;
    private Tween tween;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void LateUpdate()
    {
        if (movingLeft)
        {
            if (pos2 && (tween == null || !tween.active))
            {
                tween = target.DOMove(pos2.position, time);
                tween.onComplete += Complete;
            }
        }
        else
        {
            if (pos1 && (tween == null || !tween.active))
            {
                tween = target.DOMove(pos1.position, time);
                tween.onComplete += Complete;
            }
        }
    }

    private void Complete()
    {
        movingLeft = !movingLeft;
    }
}
