using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Doors : MonoBehaviour
{
    [SerializeField] RoomController m_RoomController1, m_RoomController2;
    [SerializeField] GameObject m_Locker;
    [SerializeField] bool m_IsWinCon;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = GameManager.Instance.Player();

        if (!Compare.GameObjects(player.gameObject, other.gameObject)) return;

        if (m_Locker != null)
        {
            if (player.HasKey)
            {
                Destroy(m_Locker);
                player.HasKey = false;
                //Key opening sound
            }
            else
            {
                //Door close sound
                return;
            }
        }
        //Win the game
        if (m_IsWinCon)
        {
            GameManager.Instance.WinGame();
            return;
        }
        m_RoomController1.gameObject.SetActive(true);
        m_RoomController2.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider c)
    {
        if (m_IsWinCon) return;
        PlayerController player = GameManager.Instance.Player();
        if (!Compare.GameObjects(c.gameObject, player.gameObject)) return;
        Physics.Raycast(player.transform.position, Vector3.down, out RaycastHit hit);
                
        if (hit.collider.gameObject.transform.IsChildOf(m_RoomController2.Floor().transform))
        {
            m_RoomController1.gameObject.SetActive(false);
            //m_RoomController1.FadeIn();
            GameManager.Instance.setCurrentRoom(m_RoomController2);
            StartCoroutine(GameManager.Instance.Camera().ChangeZPos(0.2f, m_RoomController2));
        }
        else if (hit.collider.gameObject.transform.IsChildOf(m_RoomController1.Floor().transform))
        {
            m_RoomController2.gameObject.SetActive(false);
            //m_RoomController2.FadeIn();
            GameManager.Instance.setCurrentRoom(m_RoomController1);
            StartCoroutine(GameManager.Instance.Camera().ChangeZPos(0.2f, m_RoomController1));
        }
    }
}
