using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraneMagnet : MonoBehaviour
{
    private bool grabbed;
    public GameObject grabbedObj;
    public FixedJoint craneJoint;
    public Button dropButton;
    // Start is called before the first frame update
    void Start()
    {
        grabbed = false;
        dropButton.onClick.AddListener(DropObject);
        craneJoint = gameObject.AddComponent<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey("r") && grabbed == true)
        //{
           //DropObject();
        //}
    }

    public void DropObject()
    {
        if (grabbed == true)
        {
            //Destroy(gameObject.GetComponent<FixedJoint>());
            craneJoint.connectedBody = null;
            UnityEngine.Debug.Log(craneJoint.connectedBody);
            //set to false inside coroutine to stop immediate attachment
            StartCoroutine(Wait());
            UnityEngine.Debug.Log("dropped");
            UnityEngine.Debug.Log(grabbed);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("contact");
        if ((other.gameObject.tag == "Grabbable") && (grabbed == false))
        {
            
            other.gameObject.layer = LayerMask.NameToLayer("AttachedToMagnet");
            Debug.Log(other.gameObject.layer);
            other.gameObject.transform.localEulerAngles = gameObject.transform.localEulerAngles;
            other.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - (other.gameObject.transform.localScale.y/1.5f), gameObject.transform.position.z);
            //gameObject.AddComponent(typeof(FixedJoint));
            craneJoint.connectedBody = other.GetComponent<Rigidbody>();
            grabbedObj = other.gameObject;
            other.gameObject.tag = "Grabbed";
            grabbed = true;
            
            //set to the center of the cube
            //on trigger
        }
    }
    //create coroutine to wait for a certian amount of time
    IEnumerator Wait()
    {
        UnityEngine.Debug.Log("waiting");
        yield return new WaitForSeconds(5);
        UnityEngine.Debug.Log("done");
        grabbedObj.gameObject.tag = "Grabbable";
        grabbedObj.gameObject.layer = LayerMask.NameToLayer("Default");
        grabbedObj = null;
        grabbed = false;

    }
}
