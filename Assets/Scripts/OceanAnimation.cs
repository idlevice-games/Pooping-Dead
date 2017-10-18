using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanAnimation : MonoBehaviour {

    Vector2 floatX;
    Vector2 originalX;
    Vector2 originalY;

    public float floatStrength;

    // Use this for initialization
    void Start ()
    {
        Vector2 originalX = this.transform.position;
        Vector2 originalY = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        floatX = transform.position;
        //floatX.x = (Mathf.Sin(Time.time) * floatStrength);
        //transform.position = floatX;
        this.transform.position = new Vector2(0,0);
        this.transform.position = new Vector2(1,0);
        this.transform.position = new Vector2(0, 0);
        //transform.position = -floatX;
    }
}



