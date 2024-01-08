using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] PlayerController m_Player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(m_Player.transform.position.x, transform.position.y, transform.position.z);
    }
}
