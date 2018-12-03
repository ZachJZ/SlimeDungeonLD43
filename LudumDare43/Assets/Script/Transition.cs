using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {

    private SlimeCharacter myslime;

    [SerializeField]
    private int globSize;

	// Use this for initialization
	void Start () {

        if(globSize == 0)
        {
            globSize = 1;
        }
        myslime = FindObjectOfType<SlimeCharacter>();
	}
	
	// Update is called once per frame
	void Update () {
		


	}

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            Absorb();
        }
    }

    void Absorb()
    {
        myslime.ChangeSize(globSize);
        Destroy(gameObject);
    }
}
