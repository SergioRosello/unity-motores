﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intermitent : MonoBehaviour {

	public float timer;
  void Start(){  
    StartCoroutine("HideUnhide");
	}


  IEnumerator HideUnhide(){
    while (true) {
        yield return (new WaitForSeconds(timer));
		GetComponent<Text>().enabled = true;
        yield return (new WaitForSeconds(timer));
        GetComponent<Text>().enabled = false;
    }
  }
}
