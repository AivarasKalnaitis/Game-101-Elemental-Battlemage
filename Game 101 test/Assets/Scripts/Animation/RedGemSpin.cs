using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGemSpin : MonoBehaviour
{
    private Animator []animators;

    // Start is called before the first frame update
    void Start()
    {
        animators = GetComponentsInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Animator animator in animators)
        {
            animator.Play("RedGem_Spin");
        }
    }
}
