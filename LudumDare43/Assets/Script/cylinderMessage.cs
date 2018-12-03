using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cylinderMessage : MonoBehaviour {

    private CameraMovement camMan;
    private SlimeCharacter slime;

	// Use this for initialization
	void Start () {
        camMan = FindObjectOfType<CameraMovement>();
        slime = FindObjectOfType<SlimeCharacter>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider col)
    {
        if(col.name == "Player" && slime.inRoom == false)
        {
            slime.ChangeDirection("" + name + "");
            camMan.SenderName("" + name + "");
            print("" + name + "");
        }
    }
}
