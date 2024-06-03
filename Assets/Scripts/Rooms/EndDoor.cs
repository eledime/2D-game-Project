using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDoor : MonoBehaviour
{
    public _GameManager gameManager;
    [SerializeField] private Transform previousRoom;
    [SerializeField] private CameraController cam;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //Checks if object collided with has tag Player
        {
            if (collision.transform.position.x < transform.position.x)
            {
                previousRoom.GetComponent<Room>().ActivateRoom(false);
                gameManager.LevelComplete();                

            }           
        }
    }
    public void Clicked(string Level2)
    {
        SceneManager.LoadScene(2);
    }

}
