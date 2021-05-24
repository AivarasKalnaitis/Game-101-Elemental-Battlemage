using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAnyStateAnimator : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private Dictionary<string, AnyStateAnimation> animations = new Dictionary<string, AnyStateAnimation>();

    private string currentAnimation = string.Empty;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void AddAnimations(params AnyStateAnimation[] newAnimations)
    {
        for (int i = 0; i < newAnimations.Length; i++)
        {
            this.animations.Add(newAnimations[i].Name, newAnimations[i]);
        }
    }

    public void TryPlayAnimation(string newAnimation)
    {
        PlayAnimation(ref currentAnimation);

        void PlayAnimation(ref string currentAnimation)
        {
            if (currentAnimation == "")
            {
                animator.SetTrigger(newAnimation);
            }

            else if (currentAnimation != newAnimation)
            {
                animator.ResetTrigger(currentAnimation);
                animator.SetTrigger(newAnimation);
            }
            //Animate();
        }
    }

    private void Animate()
    {
        Debug.Log("animating");
        foreach (string key in animations.Keys)
        {
            animator.SetBool(key, animations[key].Active);
        }
    }
}
