using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HiddingSpot : MonoBehaviour
{
    public GameObject hidenText, outText;
    private bool toggle, canHide;
    // Start is called before the first frame update
    void Start()
    {
        hidenText.SetActive(false);
        outText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        HiddenPlayer();
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ShowText(hidenText);
            HidenText(outText);
            canHide = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HidenText(hidenText);
            HidenText(outText);
            canHide = false;
        }
    }

    void HiddenPlayer()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame && canHide)
        {
            PlayerController player = GameManager.Instance.Player();
            player.IsHidden = !player.IsHidden;
            toggle = !toggle;
            if (player.IsHidden && toggle)
            {
                //Sound enter hidden state
                ShowText(outText);
                HidenText(hidenText);
                player.transform.gameObject.SetActive(false);
            }
            else
            {
                //Sound exit hidden state
                ShowText(hidenText);
                HidenText(outText);
                player.transform.gameObject.SetActive(true);
            }
        }
    }

    void HidenText(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    void ShowText(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
}
