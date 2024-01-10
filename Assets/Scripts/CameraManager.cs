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
    [SerializeField] Animator camAnim;
    [SerializeField] PlayerController m_Player;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, m_Player.transform.position.y, m_Player.transform.position.z));
        transform.position = new Vector3(m_Player.transform.position.x, transform.position.y, transform.position.z);
    }

    public void Shake(float speed)
    {
        camAnim.SetTrigger("TriggerShake");
        camAnim.SetFloat("ShakeSpeed", speed);
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
