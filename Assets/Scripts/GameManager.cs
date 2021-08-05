using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
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

}
