using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BubbleMove : MonoBehaviour
{
    public float speed = 2f;
    public float frequency = 20f;
    public float magnitude = 0.5f;
    public int direction = -1;
    Vector2 pos;
    Vector2 axis;

    private void Awake()
    {
        pos = transform.position;
        axis = transform.up;
        RandomizeMagnitude();

    }

    private void Update()
    {
        //transform.position += transform.forward * (speed * Time.deltaTime);

        //transform.position += transform.forward * (speed * Time.deltaTime);
        //transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
        Vector3 posAll = new Vector3(direction * speed, Mathf.Sin((Time.time * frequency)/10) * magnitude, 0f);
        transform.position += posAll * Time.deltaTime;
    }

    private void RandomizeMagnitude()
    {
        magnitude = UnityEngine.Random.Range(0.5f, 4f);
        frequency = UnityEngine.Random.Range(15f, 30f);
        speed = UnityEngine.Random.Range(1.5f, 3f);
        //Invoke("RandomizeMagnitude", 3f);
    }
}
