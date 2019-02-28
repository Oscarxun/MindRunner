using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseController : MonoBehaviour
{
    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
    }

    public void BackToMenu()
    {
        int sceneBuildIndex = 0;
        SceneManager.LoadScene(sceneBuildIndex);
        Time.timeScale = 1;
    }
}
