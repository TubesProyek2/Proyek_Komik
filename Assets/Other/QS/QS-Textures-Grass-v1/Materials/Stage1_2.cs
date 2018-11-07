using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_2 : MonoBehaviour
{    
    // Update is called once per frame
    void OnTriggerEnter()
    { Application.LoadLevel("Stage1_3"); }
}
