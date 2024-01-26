using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject inticon,sign2;
    public GameObject key,sign1;

    private bool isInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isInRange = true;
            inticon.SetActive(true);
            sign1.SetActive(true);
            sign2.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isInRange = false;
            inticon.SetActive(false);
        }
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            PickUpKey();
        }
    }

    private void PickUpKey()
    {
        key.SetActive(false);
        thirddoor.keyfound = true;
        inticon.SetActive(false);
    }
}
