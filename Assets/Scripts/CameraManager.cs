using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;
using Utils;
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
    void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, m_Player.transform.position.y, m_Player.transform.position.z));
        transform.position = new Vector3(m_Player.transform.position.x, transform.position.y, transform.position.z);
    }

    private void Update()
    {

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
            camAnim.SetFloat("ShakeSpeed", 1000f);
            camAnim.SetFloat("ShakeTime", 40f);

        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            camAnim.SetTrigger("TriggerShake");
            camAnim.SetFloat("ShakeSpeed", 5f);
            camAnim.SetFloat("ShakeTime", 30f);
        }

    }

    public IEnumerator ChangeZPos(float t, RoomController room)
    {
        float distance = room.gameObject.transform.position.z - room.CameraDistance - transform.position.z;
        float totalDistance = Math.Abs(distance);
        while (totalDistance > 0)
        {
            float z = (distance * (Time.deltaTime / t));
            transform.position = new Vector3(m_Player.transform.position.x, transform.position.y, transform.position.z + z);
            yield return null;
            totalDistance -= Math.Abs(z);
        }
    }
}
