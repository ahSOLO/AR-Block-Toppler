using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    
    [SerializeField] TMP_Text setupText;
    [SerializeField] TMP_Text shotsRemainingText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject rotateRightButton;
    [SerializeField] GameObject rotateLeftButton;

    private void Awake()
    {
        instance = this;
    }

    public void setSetupText(bool isActive, string text = null)
    {
        if (isActive)
        {
            setupText.gameObject.SetActive(true);
            if (text != null)
                setupText.text = text;
        }
        else
        {
            setupText.gameObject.SetActive(false);
        }
    }

    public void setShotsRemainingText(bool isActive, string text = null)
    {
        if (isActive)
        {
            shotsRemainingText.gameObject.SetActive(true);
            shotsRemainingText.text = text;
        }
        else
        {
            shotsRemainingText.gameObject.SetActive(false);
        }
    }

    public void setScoreText(bool isActive, string text = null)
    {
        if (isActive)
        {
            scoreText.gameObject.SetActive(true);
            scoreText.text = text;
        }
        else
        {
            scoreText.gameObject.SetActive(false);
        }
    }

    public void toggleRotationButtons(bool isActive)
    {
        rotateRightButton.SetActive(isActive);
        rotateLeftButton.SetActive(isActive);
    }
}
