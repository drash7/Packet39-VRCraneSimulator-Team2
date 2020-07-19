using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControllerBoomUpDown : MonoBehaviour
{
    public GameObject CraneControllerObj;
    //public CraneController ccscript;
    public CraneController ccscript;
    public bool up;
    public bool down;

    // Start is called before the first frame update
    void Start()
    {
        up = false;
        down = false;
        ccscript = CraneControllerObj.GetComponent<CraneController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (up) 
        {
            ccscript.MoveUp();
        }
        if (down)
        {
            ccscript.MoveDown();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("called");
        if (other.tag == "upTrigger")
        {
            up = true;
        }
        if (other.tag == "downTrigger")
        {
            down = true;
        }

    }
    public void OnTriggerExit(Collider other)
    {
        up = false;
        down = false;
    }
}
