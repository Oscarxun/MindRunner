using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject platform;
    public Transform generationPoint;
    public int distance;

    private float platformWidth;

    public float maxGap;
    public float minGap;

    //public GameObject[] platforms;
    public int platformSelector;
    private float[] platformWidths;

    public ObjectPooled[] objectPooleds;

    private CoinGenerator coinGenerator;
    public float randomCoinThreshold;
    public float randomCoinHighThreshold;

    private PowerUpGenerator powerUpGenerator;
    public float randomThreshold;

    // Use this for initialization
    void Start () {
        //platformWidth = GetComponent<BoxCollider2D>().size.x;

        platformWidths = new float[objectPooleds.Length];

        for(int i = 0; i < objectPooleds.Length; i++)
        {
            platformWidths[i] = objectPooleds[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        coinGenerator = FindObjectOfType<CoinGenerator>();
        powerUpGenerator = FindObjectOfType<PowerUpGenerator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < generationPoint.position.x)
        {
            if (Random.value < 0.1f)
                distance = (int)Random.Range(minGap, maxGap);
            else
                distance = 0;

            platformSelector = Random.Range(0, objectPooleds.Length);

            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] / 2 + distance, transform.position.y, transform.position.z);

            //Instantiate(platforms[platformSelector], transform.position, transform.rotation);

            GameObject newPlatform = objectPooleds[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            float rand = Random.Range(0f, 100f);

            if (rand < randomThreshold && PlayerController.gotMagnet == false)
            {
                powerUpGenerator.SpawnPowerUps(new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z));
            }
            else if (rand < randomCoinThreshold)
            {
                coinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z));
            }
            else if(rand < randomCoinHighThreshold)
            {
                coinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 4.0f, transform.position.z));
            }

            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] / 2, transform.position.y, transform.position.z);
        }
	}
}
