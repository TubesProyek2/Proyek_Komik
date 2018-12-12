using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMap : MonoBehaviour
{
    public GameObject miniMap;

	// Use this for initialization
	void Start ()
    { miniMap.SetActive(true); }

    void OnTriggerEnter(Collider other)
    { miniMap.SetActive(false); }
}
