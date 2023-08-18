using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TweenTest : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve _curve;

    private void Start()
    {
        transform
            .DOMove(new Vector3(0, 10, 0), 1)
            .SetEase(_curve);
    }
}


    
