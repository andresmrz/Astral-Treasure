﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{


    public GameObject textDisplay;
    public int secondsLeft = 60;
    public bool takingAway = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        textDisplay.GetComponent<TextMesh>().text = "Encuentra el tesoro!";
    }



    // Update is called once per frame
    void Update()
    {
        if(takingAway == false && secondsLeft > 0){
            StartCoroutine(TimerTake());
        }
    }
    
    IEnumerator TimerTake(){
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        textDisplay.GetComponent<TextMesh>().text = "" + secondsLeft + " Seg.";
        if(secondsLeft == 0){
            textDisplay.GetComponent<TextMesh>().text = "Loser!";
        }
        takingAway = false;
    }    
}
