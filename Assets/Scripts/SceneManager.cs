using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;

public class Menu : MonoBehaviour
{
    [SerializeField] RawImage m_BlackScreen;

    public void Start()
    {
        StartCoroutine(Anim.FadeOut(1f, m_BlackScreen));
    }
    public void Play()
    {
        StartCoroutine(FadeTransition("FinalScene"));
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

    public void Quit()
    {
        //Quit app
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
        Application.Quit();
    }
}