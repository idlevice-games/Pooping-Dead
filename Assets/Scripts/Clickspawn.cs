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
                //brick.GetComponent<Rigidbody2D>().mass = brick.transform.localScale.x * brick.transform.localScale.y * 5f;
                brick.GetComponent<Rigidbody2D>().mass = 0.2f;
                brick.transform.parent = BoatManager.transform;
            }
            else
            {
                Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

                if (hit)
                {
                    //Debug.Log("Object type clicked on: " + hit.transform.gameObject.name);
                    if (hit.transform.gameObject.name.Substring(0, 13).Equals("HullComponent"))
                    {
                        //Debug.Log("Object..: " + hit.transform.gameObject);
                        lastChild = hit.transform.gameObject;

                        // Determine what side of the hull component is hit in order to determine where to attach the next component
                        if (hit.collider.offset.x >= 0.0f)
                        {
                            if (lastChild.GetComponent<HullComponent>().rightSide == null)
                            {
                                GameObject componentObject = new GameObject();
                                componentObject = Instantiate(Brick, lastChild.transform.localPosition + new Vector3(0.65f, 0, 0), Brick.transform.rotation) as GameObject;
                                lastChild.GetComponent<HullComponent>().rightSide = componentObject;
                                componentObject.GetComponent<HullComponent>().leftSide = lastChild;
                                componentObject.AddComponent<FixedJoint2D>();
                                componentObject.GetComponent<FixedJoint2D>().connectedBody = lastChild.GetComponent<Rigidbody2D>();
                                componentObject.GetComponent<FixedJoint2D>().connectedAnchor = new Vector2(0.0f, -0.0f);
                                componentObject.GetComponent<FixedJoint2D>().breakForce = 128.0f;
                                componentObject.transform.parent = BoatManager.transform;
                            }
                            else
                            {
                                Debug.Log("Cannot connect to the right side, already have a joint to another component..");
                            }
                        }
                        else
                        {
                            if (lastChild.GetComponent<HullComponent>().leftSide == null)
                            {
                                GameObject componentObject = new GameObject();
                                componentObject = Instantiate(Brick, lastChild.transform.localPosition + new Vector3(-0.65f, 0, 0), Brick.transform.rotation) as GameObject;
                                lastChild.GetComponent<HullComponent>().leftSide = componentObject;
                                componentObject.GetComponent<HullComponent>().rightSide = lastChild;
                                componentObject.AddComponent<FixedJoint2D>();
                                componentObject.GetComponent<FixedJoint2D>().connectedBody = lastChild.GetComponent<Rigidbody2D>();
                                componentObject.GetComponent<FixedJoint2D>().connectedAnchor = new Vector2(0.0f, -0.0f);
                                componentObject.GetComponent<FixedJoint2D>().breakForce = 128.0f;
                                componentObject.transform.parent = BoatManager.transform;

                            }
                            else
                            {
                                Debug.Log("Cannot connect to the left side, already have a joint to another component..");
                            }
                        }
                    }                   
                }
                
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
    