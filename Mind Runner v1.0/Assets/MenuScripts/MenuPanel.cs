using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    public static bool isStart = false;

    public GameObject blur;
    public GameObject StorePanel;
    public GameObject SettingPanel;
    public GameObject QuitPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        int sceneBuildIndex = 1;
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public void OpenStore()
    {
        StorePanel.SetActive(true);
        gameObject.SetActive(false);
        blur.SetActive(true);
    }

    public void CloseStore()
    {
        StorePanel.SetActive(false);
        gameObject.SetActive(true);
        blur.SetActive(false);
    }

    public void OpenSetting()
    {
        SettingPanel.SetActive(true);
        gameObject.SetActive(false);
        blur.SetActive(true);
    }

    public void CloseSetting()
    {
        SettingPanel.SetActive(false);
        gameObject.SetActive(true);
        blur.SetActive(false);
    }

    public void AskSureToQuit()
    {
        QuitPanel.SetActive(true);
        gameObject.SetActive(false);
        blur.SetActive(true);
    }

    public void CloseQuit()
    {
        QuitPanel.SetActive(false);
        gameObject.SetActive(true);
        blur.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
