using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGenerator : MonoBehaviour
{
    public ObjectPooled powerUpPool;
    public GameObject powerUpTimer;

    public void SpawnPowerUps(Vector3 startPosition)
    {
        GameObject powerUp = powerUpPool.GetPooledObject();
        powerUp.transform.position = startPosition;
        powerUp.SetActive(true);
    }

    private void Update()
    {
        if(PlayerController.gotMagnet)
        {
            powerUpTimer.SetActive(true);
        }
    }
}
