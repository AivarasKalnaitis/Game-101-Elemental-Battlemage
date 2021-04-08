using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LeverBallsScript : MonoBehaviour
{
    public GameObject bouncyBalls;

    [SerializeField] private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && timer <= 0)
        {

            bouncyBalls.GetComponent<FunnyBall>().DoIt();
            timer = 10;
        }
    }
}
