using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Doors : MonoBehaviour
{
    [SerializeField] RoomController m_RoomController1, m_RoomController2;
    [SerializeField] bool m_IsLock = true;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("IS A DOOOOOOOOOR");
        PlayerController player = GameManager.Instance.Player();
        if (m_IsLock)
        {
            if (player.HasKey)
            {
                m_IsLock = false;
                player.HasKey = false;
                //Key opening sound
                Debug.Log("DOOOOR UNLOCK");
            }

            // set if player has key -> isLock == true; + remove key State
            else {
                Debug.Log("MUST HAVE A KEY");
                //Door close sound
                return;
            }  
        }
        //Debug.Log(other.gameObject);
        if (Compare.GameObjects(player.gameObject, other.gameObject))
        {
            m_RoomController1.gameObject.SetActive(true);
            m_RoomController2.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider c)
    {
        PlayerController player = GameManager.Instance.Player();
        if (!Compare.GameObjects(c.gameObject, player.gameObject)) return;
        Physics.Raycast(player.transform.position, Vector3.down, out RaycastHit hit);

        if (!Compare.GameObjects(hit.collider.gameObject, m_RoomController1.Floor()))
        {
            //m_RoomController1.gameObject.SetActive(false);
            m_RoomController1.FadeIn();
            GameManager.Instance.setCurrentRoom(m_RoomController2);
            StartCoroutine(GameManager.Instance.Camera().ChangeZPos(0.2f, m_RoomController2));
        }
        else if (!Compare.GameObjects(hit.collider.gameObject, m_RoomController2.Floor()))
        { 
            //m_RoomController2.gameObject.SetActive(false);
            
            GameManager.Instance.setCurrentRoom(m_RoomController1);
            StartCoroutine(GameManager.Instance.Camera().ChangeZPos(0.2f, m_RoomController1));
        }
    }
}
