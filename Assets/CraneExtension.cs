using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneExtension : MonoBehaviour
{

    public float movementSpeed = 2f;
    public float moveTracker = 0f;
    public GameObject craneHandle;
    public Vector3 MoveDir;
    public Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 MoveDir = (craneHandle.transform.position - transform.position).normalized;
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
        if (moveTracker < 300) {
            //Vector3 MoveDir = (craneHandle.transform.position - transform.position).normalized;
            //transform.position += MoveDir * Time.deltaTime * movementSpeed;
            Vector3 temp = transform.localScale;
            temp.z += 0.01f;
            transform.localScale = temp;
            moveTracker++;
        }
    }

    public void MoveBackward()
    {
        if (moveTracker > 0)
        {
            //Vector3 MoveDir = (craneHandle.transform.position - transform.position).normalized;
            //transform.position -= MoveDir * Time.deltaTime * movementSpeed;
            Vector3 temp = transform.localScale;
            temp.z -= 0.01f;
            transform.localScale = temp;
            moveTracker--;
        }
    }
}
