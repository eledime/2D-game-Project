using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{

    public float speed;
    public bool chase = false;
    public Transform startingPoint;
    private GameObject player;
    public int damageAmount = 1;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player == null)
            return;
        if (chase == true)
            Chase();
        else
            ReturnStartPoint();
            //go to starting position
        Flip();
    }

    private void Chase() //Chase player
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, player.transform.position)<= 0.5f)
        {
            //change speed, shoot, animation
        }
        else
        {
            //reset variables
        }

    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }

    private void Flip()  //Flip enemy to look at player
    {
        Vector3 directionToPlayer = player.transform.position - transform.position;

        if (directionToPlayer.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null )
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }

}
