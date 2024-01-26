using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thirddoor : MonoBehaviour
{
    public GameObject door_closed, door_opened;
    public AudioSource open, close;
    private bool opened, interacting;
    public static bool keyfound;

    public Text intText; // Reference to the UI Text object for interaction instructions.
    public Text getKeyText; // Reference to the UI Text object for "Go get key" message.
    public Text lockedText; // Reference to the UI Text object for displaying a locked message.

    private void Start()
    {
        intText.gameObject.SetActive(false); // Hide the interaction text initially.
        getKeyText.gameObject.SetActive(false); // Hide "Go get key" message initially.
        lockedText.gameObject.SetActive(false); // Hide the locked message initially.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (!opened)
            {
                if (keyfound)
                {
                    intText.text = "Press 'E' to open the door"; // Update the interaction text.
                    getKeyText.gameObject.SetActive(false); // Hide "Go get key" message.
                    lockedText.gameObject.SetActive(false); // Hide the locked message.
                    intText.gameObject.SetActive(true); // Show the interaction text.
                }
                else
                {
                    intText.gameObject.SetActive(false); // Hide the interaction text.
                    getKeyText.gameObject.SetActive(true); // Show "Go get key" message.
                    lockedText.gameObject.SetActive(true); // Show the locked message.
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera") && !opened && keyfound && !interacting)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Interact());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.gameObject.SetActive(false); // Hide the interaction text.
            getKeyText.gameObject.SetActive(false); // Hide "Go get key" message.
            lockedText.gameObject.SetActive(false); // Hide the locked message.
        }
    }

    private IEnumerator Interact()
    {
        interacting = true;
        door_closed.SetActive(false);
        door_opened.SetActive(true);
        intText.gameObject.SetActive(false); // Hide the interaction text.
        yield return new WaitForSeconds(4.0f);
        opened = false;
        door_closed.SetActive(true);
        door_opened.SetActive(false);
        interacting = false;
    }
}
