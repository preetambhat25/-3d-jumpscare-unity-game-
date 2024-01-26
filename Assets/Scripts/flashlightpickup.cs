using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightpickup : MonoBehaviour
{
    public GameObject flashlight_ground, inticon, flaashlight_player;

    private bool isInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inticon.SetActive(true);
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inticon.SetActive(false);
            isInRange = false;
        }
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            PickUpFlashlight();
        }
    }

    private void PickUpFlashlight()
    {
        flashlight_ground.SetActive(false); // Deactivate the flashlight on the ground
        inticon.SetActive(false); // Deactivate the icon
        flaashlight_player.SetActive(true); // Activate the player's flashlight
        gameObject.SetActive(false); // Deactivate the flashlight pickup object
    }
}
