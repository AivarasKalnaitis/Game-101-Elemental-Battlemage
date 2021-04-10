using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lotus : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.Play("Pulse");
    }
}
