using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void Start()
    { gameObject.SetActive(true); }

    void OnTriggerEnter(Collider other)
    { gameObject.SetActive(false); }
}
