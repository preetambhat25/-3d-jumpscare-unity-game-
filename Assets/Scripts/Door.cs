using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameObject door_closed, door_opened, intText, lockedtext;
    public AudioSource open, close;
    public bool opened, locked;
    public static bool keyfound;
    private void Start()
    {
        keyfound = false;

    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (opened == false)
            {
                if (locked == false)
                {
                    intText.SetActive(true);
                    if (Input.GetKey(KeyCode.E))
                    {
                        door_closed.SetActive(false);
                        door_opened.SetActive(true);
                        intText.SetActive(false);
                        
                        StartCoroutine(repeat());
                        opened = true;
                    }
                }
                if (locked == true)
                {
                    lockedtext.SetActive(true);
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            lockedtext.SetActive(false);
        }
    }
    IEnumerator repeat()
    {
        yield return new WaitForSeconds(4.0f);
        opened = false;
        door_closed.SetActive(true);
        door_opened.SetActive(false);
        
    }
    private void Update()
    {
        if (keyfound == true)
        {
            locked = false;
        }
    }
}