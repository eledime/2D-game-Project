using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public _GameManager gameManager;

    private void OnTriggerEnter()
    {
        gameManager.LevelComplete();
    }
}
