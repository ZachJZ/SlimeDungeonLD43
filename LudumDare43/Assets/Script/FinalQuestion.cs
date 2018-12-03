using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalQuestion : MonoBehaviour {

    public GameObject questionCanvas;

	// Use this for initialization
	void Start () {

        questionCanvas.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            questionCanvas.SetActive(true);
        }
    }
}
