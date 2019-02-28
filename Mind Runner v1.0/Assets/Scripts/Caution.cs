using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caution : MonoBehaviour
{
    Image caution;
    public float timer;
    public float cautionDist;

    public Transform player;
    public Transform monster;

    public bool blinked = false;

    public Text distText;
    public float dist;

    // Start is called before the first frame update
    void Start()
    {
        caution = GetComponent<Image>();
        caution.enabled = false;
        distText.enabled = true;

        dist = player.position.x - monster.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //dist = Vector2.Distance(player.position, monster.position);
        dist = player.position.x - monster.position.x;
        if (dist <= 0)
            dist = 0;
        distText.text = Mathf.Round(dist * 10).ToString() + " M";

        if (Mathf.Round(dist * 10) < 100)
            distText.color = Color.red;
        else
            distText.color = Color.white;

        if (dist < cautionDist)
        {
            StartBlinking();
        }
        else
        {
            caution.enabled = false;
            //distText.enabled = false;
        }
    }

    public void StartBlinking()
    {
        timer += Time.deltaTime;

        if (timer >= 0.5f)
        {
            caution.enabled = true;
            //distText.enabled = true;
        }
        if (timer >= 1f)
        {
            caution.enabled = false;
            timer = 0;
        }
    }
}
