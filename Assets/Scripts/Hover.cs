using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hover : MonoBehaviour
{
    Text hoverText;

    void Start()
    {
        hoverText = GameObject.Find("hoverText").GetComponent<Text>();
    }

 
}
