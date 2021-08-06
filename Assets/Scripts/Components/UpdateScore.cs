using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    TextMeshProUGUI tMP;

    private void Start()
    {
        tMP = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateScoreText(int number)
    {
        tMP.text = $"Current Score: {number}";
    }

}
