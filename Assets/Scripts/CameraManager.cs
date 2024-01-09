using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    public Animator camAnim;
    [SerializeField] PlayerController m_Player;

    private void Start()
    {
        camAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(m_Player.transform.position.x, transform.position.y, transform.position.z);

        TestShake();
    }

    public void Shake(string shakeName)
    {
        camAnim.SetTrigger(shakeName);
    }

    private void TestShake()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame )
        {
          
            camAnim.SetTrigger("TriggerShake");
            camAnim.SetFloat("ShakeSpeed", 40f);
            camAnim.SetFloat("ShakeTime", 40000f);

        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            camAnim.SetTrigger("TriggerShake");
            camAnim.SetFloat("ShakeSpeed", 5f);
            camAnim.SetFloat("ShakeTime", 90f);
        }

    }
}
