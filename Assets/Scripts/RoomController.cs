using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class RoomController : MonoBehaviour
{
    private GameManager _gm;

    [SerializeField] List<Light> m_LightsList;
    [SerializeField] GameObject m_Floor;
    [SerializeField] List<RawImage> m_ListFadeImage;
    [SerializeField] bool m_StartingRoom;
    public float CameraDistance;

    public GameObject Floor() => m_Floor;
    public List<Light> Lights() => m_LightsList;
    public List<RawImage> FadeImage() => m_ListFadeImage;

    void Start()
    {
        _gm = GameManager.Instance;
        if (!m_StartingRoom) 
            gameObject.SetActive(false);
            //FadeOut();
    }

    public void FadeOut()
    {
        foreach (RawImage image in m_ListFadeImage)
        {
            StartCoroutine(Anim.FadeIn(0.3f, image));
        }
    }

    public void FadeIn()
    {
        foreach (RawImage image in m_ListFadeImage)
        {
            StartCoroutine(Anim.FadeOut(0.3f, image));
        }
    }
}
