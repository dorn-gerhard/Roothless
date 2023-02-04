using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugStuff : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text_frameRate;
    // Update is called once per frame
    void Update()
    {
        text_frameRate.text = Mathf.RoundToInt(1f / Time.deltaTime).ToString();
    }
}