using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerNextLevel : MonoBehaviour
{
    public int nextLevel;

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
            SceneManager.LoadScene(nextLevel);

            if (nextLevel > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextLevel);
            }
        }
    }
}
