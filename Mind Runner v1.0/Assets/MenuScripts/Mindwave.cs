using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mindwave : MonoBehaviour
{
    public TGCConnectionController controller;

    public GameObject connected;
    public GameObject disconnected;

    public bool poorSignal = false;

    // Start is called before the first frame update
    void Start()
    {

        disconnected.SetActive(true);
        connected.SetActive(false);

        controller.Connect();

        controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnUpdatePoorSignal(int value)
    {
        if (value < 25)
        {
            disconnected.SetActive(false);
            connected.SetActive(true);
        }
        else if (value >= 25)
        {
            disconnected.SetActive(true);
            connected.SetActive(false);
        }
    }

    public void Reconnect()
    {
        controller.Disconnect();
        controller.Connect();
    }
}
