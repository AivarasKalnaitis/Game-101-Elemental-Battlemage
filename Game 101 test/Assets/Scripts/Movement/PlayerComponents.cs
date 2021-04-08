using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponents
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private AnyStateAnimator animator;

    public Rigidbody2D RigidBod
    {
        get { return rigidbody; }

    }

    public AnyStateAnimator Animator
    {
        get { return animator; }
    }

}
