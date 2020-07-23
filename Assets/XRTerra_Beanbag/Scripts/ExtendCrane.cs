using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendCrane : MonoBehaviour
{

    public Vector3 temp;
    public float moveTracker = 0f;
    public GameObject CraneExtension;
    public bool extend;
    public bool retract;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (extend)
        {
            if (moveTracker < 300)
            {
                //Vector3 MoveDir = (craneHandle.transform.position - transform.position).normalized;
                //transform.position += MoveDir * Time.deltaTime * movementSpeed;
                Vector3 temp = CraneExtension.transform.localScale;
                temp.z += 0.005f;
                CraneExtension.transform.localScale = temp;
                moveTracker++;
            }
        }
        if (retract)
        {
            if (moveTracker > 0)
            {
                //Vector3 MoveDir = (craneHandle.transform.position - transform.position).normalized;
                //transform.position -= MoveDir * Time.deltaTime * movementSpeed;
                Vector3 temp = CraneExtension.transform.localScale;
                temp.z -= 0.005f;
                CraneExtension.transform.localScale = temp;
                moveTracker--;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "leftTrigger")
        {
            retract = true;
        }
        if (other.tag == "rightTrigger")
        {
            extend = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        extend = false;
        retract = false;
    }
}

