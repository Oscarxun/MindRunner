using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public Text CountDownText;
    public bool pause = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(!pause)
        {
            gameObject.SetActive(false);
        }
    }

    public void BackToMenu()
    {
        int sceneBuildIndex = 0;
        SceneManager.LoadScene(sceneBuildIndex);
        Time.timeScale = 1;
    }

    public void Continue()
    {
        StartCoroutine(Countdown(3));
        //gameObject.SetActive(false);
    }

    public IEnumerator Countdown(int seconds)
    {
        int count = seconds;
        CountDownText.gameObject.SetActive(true);

        while (count > 0)
        {
            CountDownText.text = count.ToString();
            yield return new WaitForSecondsRealtime(1);
            count--;
        }

        pause = false;
        Time.timeScale = 1;
        CountDownText.gameObject.SetActive(false);
    }
}
