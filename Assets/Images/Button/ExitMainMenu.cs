using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMainMenu : MonoBehaviour {

	// Use this for initialization
	void PlayGame () {
        Application.LoadLevel(1);
	}
	
	// Update is called once per frame
	void Exit () {
        Application.Quit();
	}
}
