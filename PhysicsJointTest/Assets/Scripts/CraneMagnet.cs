using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneMagnet : MonoBehaviour
{
    private bool grabbed;
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

    void DropObject()
    {
        Destroy(gameObject.GetComponent(typeof(FixedJoint)));
        grabbed = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("contact");
        if (other.gameObject.tag == "Grabbable")
        {
            Debug.Log("contact");
            other.gameObject.transform.localEulerAngles = gameObject.transform.localEulerAngles;
            other.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - (other.gameObject.transform.localScale.y/1.5f), gameObject.transform.position.z);
            gameObject.AddComponent(typeof(FixedJoint));
            gameObject.GetComponent<FixedJoint>().connectedBody = other.GetComponent<Rigidbody>();
            
            other.gameObject.tag = "Grabbed";
            grabbed = true;
            
            //set to the center of the cube
            //on trigger
        }
    }
}
