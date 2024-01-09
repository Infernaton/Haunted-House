using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using Utils;

public class CameraManager : MonoBehaviour
{
    [SerializeField] PlayerController m_Player;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(transform.position.x, m_Player.transform.position.y, m_Player.transform.position.z));
        transform.position = new Vector3(m_Player.transform.position.x, transform.position.y, transform.position.z);
    }

    public void ChangeZPos(RoomController room)
    {
        transform.position = new Vector3(m_Player.transform.position.x, transform.position.y, room.gameObject.transform.position.z - room.CameraDistance);
    }
}
