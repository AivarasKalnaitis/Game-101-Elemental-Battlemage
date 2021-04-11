using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RedGemsUI : MonoBehaviour
{
    private TextMeshProUGUI textMP;
    public int redGemsQ = 0;

    void Start()
    {
        textMP = gameObject.GetComponent<TextMeshProUGUI>();
        textMP.SetText("" + redGemsQ);
    }

    void Update()
    {
        textMP.SetText("" + redGemsQ);
    }

    public void RedGemsPlus()
    {
        redGemsQ++;
    }
}
