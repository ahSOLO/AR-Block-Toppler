using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class UpdateShotsRemaining : MonoBehaviour
{
    TextMeshProUGUI tMP;

    private void Start()
    {
        tMP = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateShots(int number)
    {
        tMP.text = $"Ready to Fire!{Environment.NewLine}Shots Remaining: {number}";
    }

}
