using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject setupActions;
    [SerializeField] GameObject aimingActions;

    public HashSet<Rigidbody> movingObjects = new HashSet<Rigidbody>();

    public TextMeshProUGUI debugText;

    public enum GameState { Menu, Setup, Aiming, Physics };
    public GameState gState = GameState.Setup;

    private void Awake()
    {
        // Initialize Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            enabled = false;
        }
    }

    private void Update()
    {
        switch (gState)
        {
            case GameState.Menu:
                break;
            case GameState.Setup:
                setupActions.SetActive(true);
                break;
            case GameState.Aiming:
                setupActions.SetActive(false);
                aimingActions.SetActive(true);
                break;
            case GameState.Physics:
                aimingActions.SetActive(false);
                if (movingObjects.Count == 0)
                {
                    gState = GameState.Aiming;
                }
                break;
            default:
                break;
        }

        string text = "";
        foreach (var rb in movingObjects)
        {
            text += rb.velocity.sqrMagnitude.ToString() + ", ";
        }

        debugText.text = text + " " + gState.ToString();
    }

    private void LateUpdate()
    {
        switch (gState)
        {
            case GameState.Menu:
                break;
            case GameState.Setup:
                break;
            case GameState.Aiming:
                movingObjects.RemoveWhere(rb => rb.velocity.sqrMagnitude < 0.1f);
                break;
            case GameState.Physics:
                movingObjects.RemoveWhere(rb => rb.velocity.sqrMagnitude < 0.1f);
                break;
            default:
                break;
        }
    }
}
