using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpikeHead : EnemyDamage
{
    [Header("Spikehead Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private float checkTimer;
    private Vector3 destination;
    private Vector3[] directions = new Vector3[4];
    private bool attacking;

    [Header("SFX")]
    [SerializeField] private AudioClip impactSound;

    private void OnEnable()
    {
        Stop();
    }



    private void Update()
    {

        //Move spikehead to destination only if attacking
        if(attacking)
        transform.Translate(destination * Time.deltaTime * speed);

        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer < checkDelay)
                CheckForPlayer();
        }
    }
    private void CheckForPlayer()
    {
        CalculateDirections();

        //Check if spikehead sees player in all 4 directions
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

            if(hit.collider != null && !attacking)
            {
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
        
    }
    private void CalculateDirections()
    {
        directions[0] = transform.right * range; //Right direction
        directions[1] = -transform.right * range; //Left direction
        directions[2] = transform.up * range; //Up direction
        directions[3] = -transform.up * range; //Down direction
    }


    private void Stop()
    {
        destination = transform.position; //Set destination as current position so it doesnt move
        attacking = false;
    }

    private new void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.PlaySound(impactSound);
        base.OnTriggerEnter2D(collision);
        Stop(); //Stop spikehead once hits something
    }
}
