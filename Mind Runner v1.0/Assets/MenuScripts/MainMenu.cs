using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI text;
    public bool isIncreasing = false;
    public bool menuClick = false;
    public float fadeSpeed = 1.0f;

    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerController.controller.Connect();
    }

    // Update is called once per frame
    void Update()
    {
        if (!menuClick)
        {
            if (!isIncreasing)
                text.alpha += fadeSpeed * Time.deltaTime;
            else
                text.alpha -= fadeSpeed * Time.deltaTime;

            if (text.alpha > 1.0f)
            {
                isIncreasing = true;
                text.alpha = 1.0f;
            }
            else if (text.alpha < 0.0f)
            {
                isIncreasing = false;
                text.alpha = 0.0f;
            }

            if (Input.anyKeyDown)
            {
                text.alpha = 0.0f;
                menuClick = true;
                MenuPanel.isStart = true;
                menu.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuClick = false;
                MenuPanel.isStart = false;
                menu.SetActive(false);
            }
        }
    }
}
