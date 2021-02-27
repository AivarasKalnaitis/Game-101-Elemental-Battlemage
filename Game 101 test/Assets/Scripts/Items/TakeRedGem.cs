using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TakeRedGem : MonoBehaviour
{
    public GameObject TextCanvas;
    private EdgeCollider2D edgeCollider;
    private TakeRedGem script;    

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(redGemPrefab, new Vector3(0, 0, 0), Quaternion.identity);
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
            Debug.Log("Player touched me !");
            spawnRedGem();
            
        }
    }

    void spawnRedGem()
    {
        float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        GameObject newRedGem = Instantiate(gameObject, spawnPosition, Quaternion.identity);
        edgeCollider = newRedGem.GetComponent<EdgeCollider2D>();
        edgeCollider.enabled = true;
        script = newRedGem.GetComponent<TakeRedGem>();
        script.enabled = true;
    }


}
