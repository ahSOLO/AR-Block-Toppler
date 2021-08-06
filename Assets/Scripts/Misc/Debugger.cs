using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Debugger : MonoBehaviour
{
    public static Debugger instance;
    public TextMeshProUGUI debugText;

    private void Awake()
    {
        instance = this;
    }

    public void SetDebugText(string text)
    {
        debugText.text = text;
    }
}
