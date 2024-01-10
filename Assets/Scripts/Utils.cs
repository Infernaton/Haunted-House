using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public class Compare
    {
        /**
         * Compare if two gameobjects are the same instance
         */
        public static bool GameObjects(GameObject go1, GameObject go2)
        {
            return go1.GetInstanceID() == go2.GetInstanceID();
        }
    }
    public class Anim
    {
        #region TMP_Text
        public static IEnumerator FadeIn(float t, Text txt)
        {
            txt.gameObject.SetActive(true);
            txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 0);
            while (txt.color.a < 1.0f)
            {
                txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, txt.color.a + (Time.deltaTime / t));
                yield return null;
            }
        }

        public static IEnumerator FadeOut(float t, Text txt)
        {
            txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 1);
            while (txt.color.a > 0.0f)
            {
                txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, txt.color.a - (Time.deltaTime / t));
                yield return null;
            }
            txt.gameObject.SetActive(false);
        }
        #endregion

        #region CanvaGroup
        public static IEnumerator FadeIn(float t, CanvasGroup c)
        {
            c.gameObject.SetActive(true);
            c.alpha = 0f;
            while (c.alpha < 1.0f)
            {
                c.alpha += Time.deltaTime / t;
                yield return null;
            }
        }

        public static IEnumerator FadeOut(float t, CanvasGroup c)
        {
            c.alpha = 1f;
            while (c.alpha > 0.0f)
            {
                c.alpha -= Time.deltaTime / t;
                yield return null;
            }
            c.gameObject.SetActive(false);
        }
        #endregion

        #region RawImage
        public static IEnumerator FadeIn(float t, RawImage i)
        {
            i.gameObject.SetActive(true);
            i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
            while (i.color.a < 1.0f)
            {
                i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
                yield return null;
            }
        }

        public static IEnumerator FadeOut(float t, RawImage i)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
            while (i.color.a > 0.0f)
            {
                i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
                yield return null;
            }
            i.gameObject.SetActive(false);
        }
        #endregion

        #region Image
        public static IEnumerator FadeIn(float t, Image i)
        {
            i.gameObject.SetActive(true);
            i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
            while (i.color.a < 1.0f)
            {
                i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
                yield return null;
            }
        }

        public static IEnumerator FadeOut(float t, Image i)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
            while (i.color.a > 0.0f)
            {
                i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
                yield return null;
            }
            i.gameObject.SetActive(false);
        }
        #endregion

        public static IEnumerator Blink(GameObject obj, float time)
        {
            Renderer[] objectRenderers = obj.GetComponentsInChildren<Renderer>();
            bool switchAnim = true;
            float endTime = Time.time + time;
            while (endTime > Time.time)
            {
                switchAnim = !switchAnim;
                BlinkAnim(objectRenderers, switchAnim);
                yield return new WaitForSeconds(0.05f);
            }
            //To make sure the gameobject stay visible at the end of the animation
            BlinkAnim(objectRenderers, true);
        }

        private static void BlinkAnim(Renderer[] objectRenderers, bool hasToRender)
        {
            foreach (Renderer r in objectRenderers)
                r.enabled = hasToRender;
        }
    }
}
