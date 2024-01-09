using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HiddingSpot : MonoBehaviour
{

    public PlayerController player;
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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("COLLISION");
            ShowText(hidenText);
            HidenText(outText);
            canHide = true;
        }
    }

    private void OnCollisionExit(Collision collision)
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
            player.isHidden = !player.isHidden;
            toggle = !toggle;
            if (player.isHidden == true && toggle == true)
            {
                ShowText(outText);
                HidenText(hidenText);
                player.transform.gameObject.SetActive(false);
            }
            else
            {
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
