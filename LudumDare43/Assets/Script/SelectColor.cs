using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectColor : MonoBehaviour {

    public Color myColor;

    public Material slimeColor;

    public Button myButton;
    public Slider sRed, sGreen, sBlue;

    public float red, green, blue;
    // Use this for initialization
    void Start () {

        green = 1;

    }

    // Update is called once per frame
    void Update () {

        red = sRed.value;
        green = sGreen.value;
        blue = sBlue.value;

        myColor = new Color(red, green, blue);

        myButton.GetComponent<Image>().color = myColor;
        slimeColor.color = myColor;

    }

    public Color getMyColor()
    {
        return myColor;
    }
}
