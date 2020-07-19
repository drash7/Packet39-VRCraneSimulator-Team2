using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControllerUpDown : MonoBehaviour
{
    public GameObject Lever;
    public GameObject LeverJoint;
    public HingeJoint LeverHingeJoint;
    private float rotateJointLever;
    private JointMotor LeverHingeMotor;
    private string direction;
    public float speed;
    public float rotationSpeed;
    //for sound
    public bool UpDownMovement;
    //LeverHingeMotor.force += 40 * rotateJointLever;
    //LeverHingeMotor.targetVelocity = 20 * Input.GetAxis("Vertical");
    //float rotateJointLever = Input.GetAxis("Vertical") * rotationSpeed; * rotationSpeed * 5;
    //LeverHingeJoint.useMotor = true;
    //LeverHingeJoint.motor = LeverHingeMotor;

    // Start is called before the first frame update
    void Start()
    {
        UpDownMovement = false;
        rotationSpeed = 1f;
        speed = 0f;
        LeverHingeJoint = LeverJoint.GetComponent(typeof(HingeJoint)) as HingeJoint;
        LeverHingeMotor = LeverHingeJoint.motor;
    }

    // Update is called once per frame
    void Update()
    {
        rotateJointLever = speed * rotationSpeed;
        LeverHingeMotor.force += 40 * rotateJointLever;
        LeverHingeMotor.targetVelocity = 20 * speed;
        LeverHingeJoint.useMotor = true;
        LeverHingeJoint.motor = LeverHingeMotor;
    }

    public void OnTriggerEnter(Collider other)
    {
        UpDownMovement = true;
        if (other.tag == "upTrigger")
        {
            speed = 1f * Time.timeScale;
        }
        if (other.tag == "downTrigger")
        {
            speed = -1f * Time.timeScale;
        }

    }
    public void OnTriggerExit(Collider other)
    {
        speed = speed * 0f;
    }
}