using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	public KeyCode key;
	public string sceneToLoad;
	public bool anyKeyPressed;

	private Scene scene;
	
	void Start() {
	}
	
	// Update is called once per frame
	void Update () {
		if(SceneManager.GetSceneByName(sceneToLoad) != null) {
			if(anyKeyPressed && Input.anyKeyDown){
				SceneManager.LoadScene(sceneToLoad);
			} else {
				if(Input.GetKeyDown(key)) {
					SceneManager.LoadScene(sceneToLoad);
				}
			}
		} else {
			Debug.Log("La escena no existe");
		}
		
	}
}
