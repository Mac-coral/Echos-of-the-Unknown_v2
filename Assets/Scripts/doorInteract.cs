using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorInteract : MonoBehaviour
{
    public GameObject Door;
    private Animator doorOpener;
    private bool open = false;
    private AudioSource sfx;
    public LayerMask interact;
    public float maxDistance;
    public AudioClip doorClose;
    public AudioClip doorOpen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorOpener = GetComponent<Animator>();
        sfx = GetComponent<AudioSource>();
        interact = LayerMask.GetMask("Interactable");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact"))
        {
            RaycastHit interactable;
            //uses the mouse point on screen to produce raycast
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayOrigin, out interactable, maxDistance, interact))
            {
                open = !open;
                //if the door has been clicked on, door should open
                if(open = true)
                {
                    doorOpener.SetTrigger("openDoor");
                    sfx.PlayOneShot(doorOpen);
                }
                //if door is open and clicked on, door should close
                if (open = false)
                {
                    doorOpener.SetTrigger("closeDoor");
                    sfx.PlayOneShot(doorClose);
                }
            }
        }
    }
}
