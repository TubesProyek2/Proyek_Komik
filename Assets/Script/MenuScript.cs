using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayTheGame()
    { SceneManager.LoadScene("Scene1"); }
    
    public void ExitTheGame()
    { Application.Quit(); }
}