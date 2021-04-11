using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LotusUI : MonoBehaviour
{
    private TextMeshProUGUI textMP;
    public int lotusQ = 0;

    void Start()
    {
        textMP = gameObject.GetComponent<TextMeshProUGUI>();
        textMP.SetText("" + lotusQ);
    }

    void Update()
    {
        textMP.SetText("" + lotusQ);
    }

    public void LotusPlus()
    {
        lotusQ++;
    }
}
