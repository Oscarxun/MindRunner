using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController player;
    private Vector3 playerStartPoint;

    public MonsterController monster;
    private Vector3 monsterStartPoint;

    private PlatformDestructor[] platformList;

    private ScoreManager scoreManager;

    public LoseController losePanel;

    public PauseController pause;

	// Use this for initialization
	void Start () {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;
        monsterStartPoint = monster.transform.position;

        scoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause.gameObject.SetActive(true);
            pause.pause = true;
            Time.timeScale = 0;
        }
	}

    public void RestartGame()
    {
        //StartCoroutine("Restart");
        scoreManager.totalCoins += scoreManager.coinCount;
        PlayerPrefs.SetInt("Coins", scoreManager.totalCoins);
        scoreManager.scoreIncreasing = false;
        //player.gameObject.SetActive(false);
        losePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Reset()
    {
        losePanel.gameObject.SetActive(false);
        platformList = FindObjectsOfType<PlatformDestructor>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        platformGenerator.position = platformStartPoint;
        player.transform.position = playerStartPoint;
        monster.transform.position = monsterStartPoint;
        //player.gameObject.SetActive(true);

        monster.ResetSpeed();
        PlayerController.gotMagnet = false;

        scoreManager.scoreCount = 0;
        scoreManager.coinCount = 0;
        scoreManager.scoreIncreasing = true;
        Time.timeScale = 1;
    }

    //public IEnumerator Restart()
    //{
    //    scoreManager.scoreIncreasing = false;

    //    //player.gameObject.SetActive(false);
    //    yield return new WaitForSeconds(0.5f);
    //    platformList = FindObjectsOfType<PlatformDestructor>();
    //    for(int i = 0; i < platformList.Length; i++)
    //    {
    //        platformList[i].gameObject.SetActive(false);
    //    }
    //    platformGenerator.position = platformStartPoint;
    //    player.transform.position = playerStartPoint;
    //    monster.transform.position = monsterStartPoint;
    //    //player.gameObject.SetActive(true);

    //    scoreManager.scoreCount = 0;
    //    scoreManager.coinCount = 0;
    //    scoreManager.scoreIncreasing = true;
    //}
}
