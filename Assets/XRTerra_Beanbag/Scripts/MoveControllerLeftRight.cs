using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControllerLeftRight : MonoBehaviour
{
    public float rotationSpeed;
    public float speed;
    public ConfigurableJoint CabinConfigJoint;
    public float rotateJointCabin;
    private string direction;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = .25f;
        speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        rotateJointCabin = speed * rotationSpeed;
        CabinConfigJoint.transform.Rotate(0, rotateJointCabin, 0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "leftTrigger")
        {
            speed = -1f;
        }
        if (other.tag == "rightTrigger")
        {
            speed = 1f;
        }
    
    }
    public void OnTriggerExit(Collider other)
    {
        speed = speed * 0f;
    }
}
