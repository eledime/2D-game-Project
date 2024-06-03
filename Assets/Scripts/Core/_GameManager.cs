using UnityEngine;
using UnityEngine.SceneManagement;

public class _GameManager : MonoBehaviour
{
    [Header("Level Complete")]
    [SerializeField] private GameObject levelCompleteScreen;
    [SerializeField] private AudioClip completedSound;

    private void Awake()
    {
        levelCompleteScreen.SetActive(false);
    }

    #region Game Over
    //Activate level complete screen
    public void LevelComplete()
    {
        levelCompleteScreen.SetActive(true);
        SoundManager.instance.PlaySound(completedSound);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit(); //Quits the game (Only works on build)

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //Exits play mode (will only be executed in the editor)
#endif
    }
    #endregion
}