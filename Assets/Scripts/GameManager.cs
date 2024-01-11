using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Utils;

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
    private RoomController _currentRoom;
    [SerializeField] PlayerController m_Player;
    [SerializeField] CameraManager m_Camera;
    [SerializeField] Text m_FinalText;
    public PlayerController Player() => m_Player;
    public CameraManager Camera() => m_Camera;
    public Animator anim;
    public GameObject b_reload, b_main_menu;


    public bool IsEndGame() => _state == GameState.EndGame;
    

    public void setCurrentRoom(RoomController room)
    {
        _currentRoom = room;
    }

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
        m_FinalText.gameObject.SetActive(false);
        b_main_menu.SetActive(false);
        b_reload.SetActive(false);
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

        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            StartCoroutine(OpenDoor());
        }
    }


    IEnumerator OpenDoor()
    {
        m_Player.isPDO = true;
        anim.SetBool("isDoorOpened", this.m_Player.isPDO);

        yield return new WaitForSeconds(2f);
        m_Player.isPDO = false;
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
        CancelInvoke();
        _state = GameState.EndGame;
        m_FinalText.text = "Tu as gagné !!";
        StartCoroutine(Anim.FadeIn(0.2f, m_FinalText));
        // Finishing Game
        b_main_menu.SetActive(true);
        b_reload.SetActive(true);
    }

    public void LoseGame()
    {
        m_Player.isDead = true;
        CancelInvoke();
        _state = GameState.EndGame;
        m_FinalText.text = "Tu es mort ...";
        b_main_menu.SetActive(true);
        b_reload.SetActive(true);
        StartCoroutine(Anim.FadeIn(0.2f, m_FinalText));
            for (int i = 0; i < _currentRoom.Lights().Count; i++)
            {
                Light light = _currentRoom.Lights()[i];
                light.enabled = false;
            }
        //Set Animation Lose Game
        anim.SetBool("isDead", m_Player.isDead);
    }
}
