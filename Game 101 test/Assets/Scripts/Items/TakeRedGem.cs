using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TakeRedGem : MonoBehaviour
{
    public GameObject TextCanvas;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other )
    {
        if (other.CompareTag("Player"))
        {
            TextCanvas.GetComponent<RedGemsUI>().RedGemsPlus();

            Destroy(gameObject);


        }

    }


}
