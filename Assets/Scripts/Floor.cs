using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Floor : MonoBehaviour
{
    [SerializeField] List<Light> m_LightsList;

    public void OnCollisionEnter(Collision c)
    {
        if (!Compare.GameObjects(c.gameObject, GameManager.Instance.Player().gameObject)) return;

        for (int i = 0; i < m_LightsList.Count; i++)
        {
            Light light = m_LightsList[i];
            light.enabled = true;
        }
    }

    public void OnCollisionExit(Collision c)
    {
        if (!Compare.GameObjects(c.gameObject, GameManager.Instance.Player().gameObject)) return;

        for (int i = 0; i < m_LightsList.Count; i++)
        {
            Light light = m_LightsList[i];
            light.enabled = false;
        }
    }
}
