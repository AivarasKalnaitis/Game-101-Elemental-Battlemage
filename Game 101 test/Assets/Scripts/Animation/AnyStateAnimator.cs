using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyStateAnimator : MonoBehaviour
{
    private Animator animator;

    private Dictionary<string, AnyStateAnimation> animations = new Dictionary<string, AnyStateAnimation>();

    private string currentAnimationsLegs = string.Empty;

    private string currentAnimationBody = string.Empty;

    private string currentAnimationArms = string.Empty;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void AddAnimations(params AnyStateAnimation[] newAnimations) 
    {
        for(int i = 0; i < newAnimations.Length; i++)
        {
            this.animations.Add(newAnimations[i].Name, newAnimations[i]);
        }
    }
}
