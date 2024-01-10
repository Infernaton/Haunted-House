using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;

public class Menu : MonoBehaviour
{
    [SerializeField] RawImage m_BlackScreen;
    [SerializeField] RawImage m_SignBG = null;

    public void Start()
    {
        StartCoroutine(Anim.FadeOut(1f, m_BlackScreen));
    }
    public void Play(Texture texture = null)
    {
        if (texture != null) m_SignBG.texture = texture;
        StartCoroutine(FadeTransition("FinalScene"));
    }
    public void New(Texture texture = null)
    {
        Debug.Log("test");
        if (texture != null) m_SignBG.texture = texture;
    }

    public void MainMenu()
    {
        StartCoroutine(FadeTransition("MenuScene"));
    }

    IEnumerator FadeTransition(string scene)
    {
        StartCoroutine(Anim.FadeIn(0.3f, m_BlackScreen));
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(scene);
    }

    

    public void Quit(Texture texture = null)
    {
        //Quit app
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        if (texture != null) m_SignBG.texture = texture;
        Application.Quit();
    }
}