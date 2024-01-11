using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

public class PlayerController : MonoBehaviour
{
    private Vector2 _movement;
    private Rigidbody _rigidBody;
    public bool IsHidden;
    public bool HasKey, isDead, isPDO;
    public Animator animator;

    private float horizontalInput;
    private float forwardInput;

    public float rotationSpeed;

    [SerializeField] private int m_MovementSpeed;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        isDead = false;
        isPDO = false;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        animator.SetFloat("Vertical", forwardInput);
        animator.SetFloat("Horizontal", horizontalInput);
        Vector3 movementDirection = new Vector3(horizontalInput, 0, forwardInput);
        movementDirection.Normalize();

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            _rigidBody.velocity = new Vector3(_movement.x * m_MovementSpeed, _rigidBody.velocity.y, _movement.y * m_MovementSpeed);
        }
    }

    public void OnMove(InputValue value)
    {
        if (IsHidden || GameManager.Instance.IsEndGame())
        {
            _movement = Vector2.zero;
        }
        else
        {
            // Walk Sound
            _movement = value.Get<Vector2>();

        }
    }
}
