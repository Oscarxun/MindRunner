using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStore : MonoBehaviour
{
    public int coinCount;
    public Text coins;

    public int magnetLv;
    public Button upgrade;
    public int price = 0;
    public Text priceText;

    public Text magnetLvText;

    public GameObject Warning;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            coinCount = PlayerPrefs.GetInt("Coins");
        }
        else
        {
            coinCount = 0;
        }

        if (PlayerPrefs.HasKey("MagnetLv"))
        {
            magnetLv = PlayerPrefs.GetInt("MagnetLv");
        }
        else
        {
            magnetLv = 1;
        }
        magnetLvText.text = "LV " + magnetLv.ToString() + " > LV " + (magnetLv + 1).ToString();
        price += (200*magnetLv);
        priceText.text = price.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = coinCount.ToString();
        if(price > coinCount)
        {
            Warning.SetActive(true);
        }
        else
        {
            Warning.SetActive(false);
        }
    }

    public void UpgradeMagnet()
    {
        //if (coinCount > price)
        {
            if (magnetLv < 5)
            {
                magnetLv++;
                magnetLvText.text = "LV " + magnetLv.ToString() + " > LV " + (magnetLv + 1).ToString();
                coinCount -= price;
                PlayerPrefs.SetInt("Coins", coinCount);
                price += (200 * magnetLv);
                priceText.text = price.ToString();
                PlayerPrefs.SetInt("MagnetLv", magnetLv);
            }

            if (magnetLv == 5)
            {
                upgrade.interactable = false;
                magnetLvText.text = "LV " + magnetLv.ToString() + " MAX";
                priceText.text = "-";
            }
            //Debug.Log(magnetLv);
        }
    }
}
