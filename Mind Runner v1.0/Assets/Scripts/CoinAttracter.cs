using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAttracter : MonoBehaviour
{
    public Transform Target;
    //public bool isAttract = false;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if (PlayerController.gotMagnet)
            //isAttract = true;

        if(PlayerController.gotMagnet && (Vector2.Distance(transform.position, Target.position) < 5))
        {
            
            transform.position = Vector2.MoveTowards(transform.position, Target.position, 1f);
        }

        //if(!gameObject.activeSelf)
        //{
            //isAttract = false;
        //}
    }
}
