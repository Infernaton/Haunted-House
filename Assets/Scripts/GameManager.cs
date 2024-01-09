using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    Menu, // In the gameMenu Before the game itself
    WaitingMonster,
    InComming,
    EndGame // End game state
}

public class GameManager : MonoBehaviour
{
    private GameState _state;
    [SerializeField] PlayerController m_Player;
    [SerializeField] CameraManager m_Camera;
    public PlayerController Player() => m_Player;
    public CameraManager Camera() => m_Camera;


    public static GameManager Instance; // A static reference to the GameManager instance
    void Awake()
    {
        if (Instance == null) // If there is no instance already
        {
            Instance = this;
        }
        else if (Instance != this) // If there is already an instance and it's not `this` instance
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
    }

    private void Start()
    {
        ResetMonster();
    }

    private void Update()
    {
        switch (_state)
        {
            case GameState.WaitingMonster:
                break;
            case GameState.InComming:
                if (!m_Player.isHidden) LoseGame();
                break;
            case GameState.Menu:
            case GameState.EndGame:
            default: break;
        }
    }

    private void FirstWarning()
    {
        Debug.Log("First Warning");
        Invoke(nameof(SecondWarning), 10f);
    }

    private void SecondWarning()
    {
        Debug.Log("Second Warning");
        Invoke(nameof(LastWarning), 5f);
    }

    private void LastWarning()
    {
        Debug.Log("Last Warning");
        Invoke(nameof(InComming), 5f);
    }

    private void InComming()
    {
        Debug.Log("In Comming");
        _state = GameState.InComming;
        Invoke(nameof(ResetMonster), 5f);
    }

    private void ResetMonster()
    {
        Debug.Log("Reset");
        _state = GameState.WaitingMonster;
        Invoke(nameof(FirstWarning), 10f);
    }

    private void WinGame()
    {
        // Finishing Game
    }

    private void LoseGame()
    {
        //Set Animation Lose Game
    }
}
