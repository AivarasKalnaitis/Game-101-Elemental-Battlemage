using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnyStateAnimator : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private Dictionary<string, AnyStateAnimation> animations = new Dictionary<string, AnyStateAnimation>();

    private string currentAnimationsLegs = string.Empty;

    private string currentAnimationBody = string.Empty;

    private string currentAnimationArms = string.Empty;

    private void Update()
    {
    }
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

    public void TryPlayAnimation(string newAnimation)
    {
        switch (animations[newAnimation].AnimationRig)
        {
            case RIG.BODY:
                PlayAnimation(ref currentAnimationBody);
                break;
            case RIG.LEGS:
                PlayAnimation(ref currentAnimationsLegs);
                break;
            case RIG.ARMS:
                PlayAnimation(ref currentAnimationArms);
                break;
        }

        void PlayAnimation(ref string currentAnimation)
        {
            if (currentAnimation == "")
            {
                animations[newAnimation].Active = true;
                currentAnimation = newAnimation;
                animator.Play(currentAnimation);

            }
            else if (currentAnimation != newAnimation)
            {
                animations[currentAnimation].Active = false;
                animations[newAnimation].Active = true;
                currentAnimation = newAnimation;
                animator.Play(currentAnimation);

            }
            Animate();
        }


    }

    private void Animate()
    {
        foreach (string key in animations.Keys)
        {
            animator.SetBool(key, animations[key].Active);
        }
    }
}
