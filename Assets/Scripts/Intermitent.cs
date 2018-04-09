using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intermitent : MonoBehaviour {

	public float timer;
  void Start(){  
    StartCoroutine("HideUnhide");
	}


  IEnumerator HideUnhide(){
    while (true) {
        yield return (new WaitForSeconds(timer));
        gameObject.SetActive(true);
        yield return (new WaitForSeconds(timer));
        gameObject.SetActive(false);
    }
  }
}
