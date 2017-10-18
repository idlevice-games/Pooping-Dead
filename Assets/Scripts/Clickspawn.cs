using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Clickspawn : MonoBehaviour {

    public GameObject Brick;
    public GameObject BoatManager;

    private int childCount;
    private GameObject lastChild;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            childCount = BoatManager.transform.childCount;

            if (childCount == 0)
            {
                GameObject brick = Instantiate(Brick, Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10)), Brick.transform.rotation) as GameObject;

                //brick.transform.Rotate(0, 0, UnityEngine.Random.Range(0, 0));
                //brick.transform.localScale = new Vector3(UnityEngine.Random.Range(1f, 2f),0.6f,1)*0.4f;
                brick.GetComponent<Rigidbody2D>().mass = brick.transform.localScale.x * brick.transform.localScale.y * 5f;
                //brick.AddComponent<FixedJoint2D>();
                brick.transform.parent = BoatManager.transform;

                //BoatManager.AddComponent<Rigidbody2D>();
                //BoatManager.GetComponent<Rigidbody2D>().useAutoMass = true;
                //brick.AddComponent<FixedJoint2D>();
                //brick.GetComponent<FixedJoint2D>().connectedBody = BoatManager.GetComponent<Rigidbody2D>();

                //BoatManager.transform.SetPositionAndRotation(brick.transform.position, Brick.transform.rotation);

            }
            else
            {
                Debug.Log("Child count: " + childCount);
                lastChild = BoatManager.transform.GetChild(childCount - 1).gameObject;


                GameObject brick = Instantiate(Brick, lastChild.transform.localPosition + new Vector3(1, 0, 0), Brick.transform.rotation) as GameObject;
                brick.AddComponent<FixedJoint2D>();
                brick.GetComponent<FixedJoint2D>().connectedBody = lastChild.GetComponent<Rigidbody2D>();
                brick.GetComponent<FixedJoint2D>().connectedAnchor = new Vector2(0.0f, -0.0f);
                brick.GetComponent<FixedJoint2D>().breakForce = 128.0f;                
                brick.transform.parent = BoatManager.transform;

            }
        }
        if (Input.GetMouseButtonDown(1))
        {
                GameObject brick = Instantiate(Brick, Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10)), Brick.transform.rotation) as GameObject;

                brick.transform.Rotate(0, 0, UnityEngine.Random.Range(0, 0));
                
                brick.transform.localScale = new Vector3(UnityEngine.Random.Range(1f, 2f), 0.6f, 1) * 0.4f;             
                brick.GetComponent<Rigidbody2D>().mass = 2.5f;

        }
        
    }
}
