using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
