using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{


    public void onMouseOver()
    {
        gameObject.GetComponentInChildren<Text>().fontSize = 75;
    }

    public void OnMouseExit()
    {
        gameObject.GetComponentInChildren<Text>().fontSize = 50;      
    }

    public void OnMouseClick()
    {
        gameObject.GetComponentInChildren<Text>().fontSize = 60; 
    }
}
