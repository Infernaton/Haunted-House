using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class RoomController : MonoBehaviour
{
    private GameManager _gm;

    [SerializeField] List<Light> m_LightsList;
    [SerializeField] GameObject m_Floor;
    public float CameraDistance;

    public GameObject Floor() => m_Floor;
    public List<Light> Lights() => m_LightsList;

    void Start()
    {
        _gm = GameManager.Instance;
    }
}
