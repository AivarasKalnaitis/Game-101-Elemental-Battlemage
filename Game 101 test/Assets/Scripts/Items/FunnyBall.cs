using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class FunnyBall : MonoBehaviour
{
    private Rigidbody2D[] rbs;
    [SerializeField] private float forceModifier = 500f;
    // Start is called before the first frame update
    void Start()
    {
        forceModifier = 500;
        rbs = GetComponentsInChildren<Rigidbody2D>();
    }

    public void DoIt()
    {
        foreach (Rigidbody2D rb in rbs)
        {
            Vector2 funnyForce = new Vector2(Random.Range(-100, 100) * forceModifier,
                Random.Range(-100, 100) * forceModifier);
            rb.AddForce(funnyForce);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
