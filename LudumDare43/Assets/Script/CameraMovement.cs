using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField]
    string sender;

    [SerializeField]
    float horizontal;
    [SerializeField]
    float vertical;

    //public GameObject gStart;
    //public GameObject gLeft; //15 not
    //public GameObject gDown; //17 not


	// Use this for initialization
	void Start ()
    {
        sender = "waiting";

        horizontal = 22;
        vertical = -14;

    }

    // Update is called once per frame
    void Update ()
    {
        switch (sender)
        {
            case "up":
                //do this
                transform.position = new Vector3 (transform.position.x + vertical, transform.position.y, transform.position.z) ;
                sender = "waiting";
                break;

            case "left":
                //do this
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - horizontal);
                sender = "waiting";
                break;

            case "down":
                //do this
                transform.position = new Vector3(transform.position.x - vertical, transform.position.y, transform.position.z);
                sender = "waiting";

                break;

            case "right":
                //do this
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + horizontal);
                sender = "waiting";

                break;

            case "waiting":
            //do nothing
            break;

            default:
                Debug.LogError("Something went wrong at the switch in CameraMovement");
                break;
        }
	}

    public void SenderName(string direction)
    {
        sender = direction;
    }
}
