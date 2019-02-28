using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Button : Selectable
{
    private readonly BaseEventData check;
    public Text upgrade;

    void Update()
    {
        if(IsHighlighted(check) && interactable)
        {
            upgrade.color = Color.white;
        }
        else
        {
            upgrade.color = Color.black;
        }

        if(!interactable)
        {
            upgrade.text = "FULLY UPGRADED";
        }
    }
}
