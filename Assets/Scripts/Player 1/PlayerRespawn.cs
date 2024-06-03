using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    [SerializeField] private AudioClip checkpointSound; //Sound that we'll play when picking up a new checkpoint
    private Transform currentCheckpoint; //We'll store our last checkpoint here
    private Health playerHealth;
    private UIManager uiManager;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void CheckRespawn()
    {
        //Check if checkpoint available
        if(currentCheckpoint == null)
        {
            //Show game over screen
            uiManager.GameOver();

            return; //Dont execute the rest of this function
        }


        playerHealth.Respawn(); //Restore player health and reset animation
        transform.position = currentCheckpoint.position; //Move player to checkpoint position

        //Move camera to checkpoint room (for this to work the checkpoint objects has to be  placed as a child of the room object)
        Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }

    //Activate checkpoints
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform; //Store the checkpoint that we activated as the current one
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false; //Deactivate checkpoint collider
            collision.GetComponent<Animator>().SetTrigger("appear"); //trigger checkpoint animation
        }
    }


}
