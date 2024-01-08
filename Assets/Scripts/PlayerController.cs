using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 _movement;
    private Rigidbody _rigidBody;
    [SerializeField] private int m_MovementSpeed;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = new Vector3(_movement.x * m_MovementSpeed, _rigidBody.velocity.y, _movement.y * m_MovementSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }
}
