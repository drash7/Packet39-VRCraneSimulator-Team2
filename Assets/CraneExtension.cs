using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneExtension : MonoBehaviour
{

    public float movementSpeed = 2f;
    public float moveTracker = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            MoveForward();
        }
        if (Input.GetKey("down"))
        {
            MoveBackward();
        }
    }

    public void MoveForward()
    {
        if (moveTracker < 350) {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
            moveTracker++;
        }
    }

    public void MoveBackward()
    {
        if (moveTracker > 0)
        {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
            moveTracker--;
        }
    }
}
