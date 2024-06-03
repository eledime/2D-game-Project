using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearCollectible : MonoBehaviour
{

    [SerializeField] private AudioClip pickupSound;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory playerInventory = collision.GetComponent<PlayerInventory>();
        SoundManager.instance.PlaySound(pickupSound);


        if (playerInventory != null )
        {
            
            playerInventory.PearCollected();
            gameObject.SetActive(false);
        }
    }
}
