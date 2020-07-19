using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneMagnet : Singleton<CraneMagnet>
{
    private bool grabbed;
    public GameObject grabbedObj;
    // Start is called before the first frame update
    void Start()
    {
        grabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("r") && grabbed == true)
        {
            DropObject();
        }
    }

    public void DropObject()
    {
        grabbedObj.gameObject.tag = "Grabbable";
        grabbedObj.gameObject.layer = LayerMask.NameToLayer("Default");
        Destroy(gameObject.GetComponent(typeof(FixedJoint)));
        grabbed = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("contact");
        if (other.gameObject.tag == "Grabbable")
        {
            Debug.Log("contact");
            other.gameObject.layer = LayerMask.NameToLayer("AttachedToMagnet");
            Debug.Log(other.gameObject.layer);
            other.gameObject.transform.localEulerAngles = gameObject.transform.localEulerAngles;
            other.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - (other.gameObject.transform.localScale.y/1.5f), gameObject.transform.position.z);
            gameObject.AddComponent(typeof(FixedJoint));
            gameObject.GetComponent<FixedJoint>().connectedBody = other.GetComponent<Rigidbody>();
            grabbedObj = other.gameObject;
            other.gameObject.tag = "Grabbed";
            grabbed = true;
            
            //set to the center of the cube
            //on trigger
        }
    }
}
