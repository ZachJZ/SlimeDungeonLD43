using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SlimeCharacter : MonoBehaviour {

    [SerializeField]
    public int pSize, pScore;
    [SerializeField]
    private Vector3 pLocation = new Vector3(0,0,0);
    [SerializeField]
    private Vector3 pDestination = new Vector3(0, 0, 0);
    [SerializeField]
    private Vector3 sStart = new Vector3(0, 0, 0);
    [SerializeField]
    private Vector3 sTarget = new Vector3(0, 0, 0);
    [SerializeField]

    private float distance = 2f, currentlerpTime = 0, lerpTime = 1f, vertical = 0f, horizontal = 0f, scaleTime, currentScaleTime;
    [SerializeField]
    private bool moveIt = false, gainEnterance = false, stopLerp = false, gamePaused;
    [SerializeField]
    private string direction = "nothing";

    public bool inRoom;
    [SerializeField]
    private GameObject ref1, ref2, myLock, myCage;

    private SelectColor myColorSetter;

    //menus
    public GameObject pauseMenu, Scoreboard, question;

    // Use this for initialization
    void Start () {

        myCage.SetActive(false);
        myLock.SetActive(false);
        pLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        pSize = 1;
        //print("Change size back to proper starting size!!!!!!!!!!!!");
        sStart = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        gamePaused = false;
        myColorSetter = FindObjectOfType<SelectColor>();

        if (myColorSetter == null)
        {
            print("color setter is null");
        }
    }

    // Update is called once per frame
    void Update()
    {

        EscapeMenu();

        ReflectionsOn();

        AdjustScale();

        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
            //print("rounding position");
        if (!moveIt)
        {
            MovementInput();
        }
        else
        {
            ActivateMovement();

        }

        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    ChangeSize(1);
        //}

        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    ChangeSize(-1);
        //}

        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    if (!stopLerp)
        //        stopLerp = true;

        //    else if (stopLerp)
        //        stopLerp = false;
        //}


    }

    void Score()
    {
        pScore++;
        Scoreboard.GetComponent<Text>().text = pScore.ToString();
    }

    void EscapeMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gamePaused)
            {
                gamePaused = true;
                pauseMenu.SetActive(true);
            }

            else
            {
                gamePaused = false;
                pauseMenu.SetActive(false);

            }
        }
    }

    void ResetSwitch()
    {
        direction = "nothing";
        gainEnterance = false;
        //GetComponent<BoxCollider>().enabled = true;
        //Debug.LogWarning("collider is turning on");

    }

    void MovementInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            pDestination = new Vector3(Mathf.Round((pLocation.x - distance) * 2) * 0.5f, pLocation.y, pLocation.z);
            moveIt = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            pDestination = new Vector3(Mathf.Round((pLocation.x + distance) * 2) * 0.5f, pLocation.y, pLocation.z);
            moveIt = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            pDestination = new Vector3(pLocation.x, pLocation.y, Mathf.Round((pLocation.z - distance) * 2) * 0.5f);
            moveIt = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            pDestination = new Vector3(pLocation.x, pLocation.y, Mathf.Round((pLocation.z + distance) * 2) * 0.5f);
            moveIt = true;
        }

    }

    public void ActivateMovement()
    {
        if (!stopLerp)
        {
            currentlerpTime += Time.deltaTime * 2 * (6 - pSize);
            if (currentlerpTime >= lerpTime)
            {
                currentlerpTime = lerpTime;
                pLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                moveIt = false;
                currentlerpTime = 0;
            }

            float perc = currentlerpTime / lerpTime;
            transform.position = Vector3.Lerp(pLocation, pDestination, perc);

        }

        else
        {
            currentlerpTime += Time.deltaTime * 2 * (6 - pSize);
            if (currentlerpTime >= lerpTime)
            {
                currentlerpTime = lerpTime;
                pLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                moveIt = false;
                currentlerpTime = 0;
                stopLerp = false;

            }

            float perc = currentlerpTime / lerpTime;
            transform.position = Vector3.Lerp(transform.position, pLocation, perc);

        }

    }

    public void ChangeSize(int newSize)
    {
        if (newSize + pSize > 0 && newSize + pSize < 4)
            pSize += newSize;
        //currentlerpTime = 0f;
    }

    public void ChangeDirection(string newDirection)
    {
        direction = newDirection;
    }

    void BounceOff()
    {
        stopLerp = true;

    }

    void ReflectionsOn()
    {
        if (pSize >= 2)
        {
            ref1.GetComponent<SpriteRenderer>().enabled = true;
        }

        else
        {
            ref1.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (pSize >= 3)
        {
            ref1.GetComponent<SpriteRenderer>().enabled = true;
            ref1.GetComponent<SpriteRenderer>().enabled = true;

        }

        else
        {
            ref1.GetComponent<SpriteRenderer>().enabled = false;
        }

    }

    void AdjustScale()
    {
        if(transform.localScale.x != pSize)
        {
            //print("running scale lerp");
            //currentScaleTime += Time.deltaTime * 2;
            //if (currentScaleTime >= scaleTime)
            //{
            //    currentScaleTime = lerpTime;
            //    sStart = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
            //    currentScaleTime = 0;
            //}

            //float perc = currentScaleTime / scaleTime;
            //transform.localScale = Vector3.Lerp(sStart, new Vector3(pSize, 1, pSize), perc);

            transform.localScale = Vector3.Lerp(sStart, new Vector3(pSize, 1, pSize), 3);

        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Wall")
        {
            BounceOff();
        }

        else if (col.name == "4")
        {
            if (pSize > 4)
            {
                BounceOff();

            }
        }

        else if (col.name == "3")
        {
            if (pSize > 3)
            {
                BounceOff();

            }
        }

        else if (col.name == "2")
        {
            if (pSize > 2)
            {
                BounceOff();

            }
        }

        else if (col.name == "1")
        {
            if (pSize > 1)
            {
                BounceOff();

            }
        }

        if (col.name == "Pit")
        {
            if(col.GetComponent<PitFilled>().isFilled == true)
            {

            }

            else if (pSize > 1)
            {
                ChangeSize(-1);
                col.GetComponent<PitFilled>().isFilled = true;
                col.GetComponent<SpriteRenderer>().color = myColorSetter.getMyColor();
            }

            else
            {
                BounceOff();
            }
        }


        if (col.name == "Treasure")
        {
            Score();
            Destroy(col.gameObject);
        }

        if (col.name == "Death")
        {
            distance = 0;
            myLock.SetActive(true);
            transform.localScale = Vector3.Lerp(sStart, new Vector3(0, 0, 0), 10.0f);
            Destroy(question);

            Destroy(gameObject, 3.0f);
        }

        if(col.name == "Riches")
        {
            myCage.SetActive(true);
            myLock.SetActive(true);
            Destroy(question);
        }




    }

    void OnTriggerStay(Collider col)
    {
        if (col.name == "Room")
        {
            inRoom = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.name == "Room")
        {
            inRoom = false;

        }
    }
}
