using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string scene;

    void Start()
    { Screen.SetResolution(800, 600, true); }

    public void PlayTheGame()
    { SceneManager.LoadScene(scene); }
    
    public void ExitTheGame()
    { Application.Quit(); }
}