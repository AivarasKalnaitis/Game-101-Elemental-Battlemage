using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class BookHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerPos;
    [SerializeField] private float yDivision;
    [SerializeField] private float xMultiplication;
    [SerializeField] private float deltaSpeed;

    void Start()
    {
        Vector2 startPos = new Vector2(-0.8f + playerPos.transform.position.x, 0.135f + playerPos.transform.position.y);
        transform.position = startPos;
    }

    void FixedUpdate()
    {
        BookMovingVectors();
    }
    private void BookMovingVectors()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 addedPos = new Vector2(Input.mousePosition.x / Screen.width,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y - playerPos.position.y);
        if (addedPos.y < -2)
        {
            addedPos.y = -2f;
        }

        int doesAdd = -1;
        if (addedPos.x >= 0.5f)
        {
            doesAdd = 1;
        }

        addedPos.x = (Mathf.Abs(0.5f - addedPos.x)) * doesAdd;
        Vector3 targetPosition = new Vector3(((addedPos.x) * xMultiplication + playerPos.position.x),
            (playerPos.position.y + 0.135f + addedPos.y / yDivision), 0f);
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * deltaSpeed);

    }

    public void Flip()
    {
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}