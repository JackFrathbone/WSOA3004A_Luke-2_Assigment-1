using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void sceneChanger(int level)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);
    }
}