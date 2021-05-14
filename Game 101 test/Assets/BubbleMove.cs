using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMove : MonoBehaviour
{
    public float speed = 2f;
    float frequency = 10f;
    float magnitude = 0.5f;

    Vector2 pos;
    Vector2 axis;

    private void Awake()
    {
        pos = transform.position;
        axis = transform.up;
    }

    private void Update()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);

        transform.position += transform.forward * (speed * Time.deltaTime);
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}
