using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyManager : MonoBehaviour
{
    private bool _canPickup;
    [SerializeField] private GameObject key;
    public GameObject PickupText;

    void Start()
    {
        PickupText.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ShowText(PickupText);
            _canPickup = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HidenText(PickupText);
            _canPickup = false;
        }
    }
    void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame && _canPickup)
        {
            //Pickup key sound
            GameManager.Instance.Player().HasKey = true;
            Destroy(key);
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
