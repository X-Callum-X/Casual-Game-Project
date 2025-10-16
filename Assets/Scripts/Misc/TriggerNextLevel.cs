using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerNextLevel : MonoBehaviour
{
    private int nextLevel;

    private void Start()
    {
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void LoadNextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 6)
        {
            return;
        }
        else
        {
            if (nextLevel > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextLevel);
            }
        }
    }
}
