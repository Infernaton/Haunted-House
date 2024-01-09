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

    public bool IsEndGame() => _state == GameState.EndGame;

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
        ResetMonster(); // Launch it after tutorial
    }

    private void Update()
    {
        switch (_state)
        {
            case GameState.WaitingMonster:
                break;
            case GameState.InComming:
                if (!m_Player.IsHidden) LoseGame();
                m_Camera.Shake(2f);
                //Make sound effect
                break;
            case GameState.Menu:
            case GameState.EndGame:
            default: break;
        }
    }

    private void FirstWarning()
    {
        Debug.Log("First Warning");

        m_Camera.Shake(1.15f);
        Invoke(nameof(SecondWarning), 10f);
    }

    private void SecondWarning()
    {
        Debug.Log("Second Warning");
        m_Camera.Shake(1.5f);
        Invoke(nameof(LastWarning), 5f);
    }

    private void LastWarning()
    {
        Debug.Log("Last Warning");
        m_Camera.Shake(1.6f);
        Invoke(nameof(InComming), 5f);
    }

    private void InComming()
    {
        Debug.Log("In Comming");
        _state = GameState.InComming;
        Invoke(nameof(ResetMonster), 3.5f);
    }

    private void ResetMonster()
    {
        Debug.Log("Reset");
        _state = GameState.WaitingMonster;
        m_Camera.Shake(0.4f);
        Invoke(nameof(FirstWarning), 10f);
    }

    public void WinGame()
    {
        _state = GameState.EndGame;
        // Finishing Game
    }

    public void LoseGame()
    {
        _state = GameState.EndGame;
        Debug.Log("You Lose !");
        //Set Animation Lose Game
    }
}
