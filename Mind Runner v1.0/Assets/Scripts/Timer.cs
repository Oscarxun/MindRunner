using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject powerUpTimer;
    public Image timer;
    public float currentAmount;
    public float speed;
    public int magnetLv;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Image>();
        if (PlayerPrefs.HasKey("MagnetLv"))
        {
            magnetLv = PlayerPrefs.GetInt("MagnetLv");
        }
        else
        {
            magnetLv = 1;
        }
        speed = 40 - (magnetLv * 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.gotMagnet && currentAmount > 0)
        {
            currentAmount -= speed * Time.deltaTime;
        }
        else
        {
            PlayerController.gotMagnet = false;
            powerUpTimer.SetActive(false);
            currentAmount = 100;
        }

        timer.fillAmount = currentAmount / 100;
    }
}
