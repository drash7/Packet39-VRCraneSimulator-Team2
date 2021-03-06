﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    // Start is called before the first frame update

    //public GameObject Lever;
    //public GameObject LeverJoint;
    //public HingeJoint LeverHingeJoint;
    public GameObject Cabin;
    public ConfigurableJoint CabinConfigJoint;
    public GameObject MagnetHandle;
    private SpringJoint MagnetJoint;
    public float rotationSpeed = 1;
    private float rotateJointCabin;
    //private float rotateJointLever;
    public float maxDistanceMagnet;
    private float angle;
    private JointMotor LeverHingeMotor;
    //private JointLimits hingeJ;

    public AudioSource CraneMovingSound;
    public GameObject UpDownTrigger;
    public MoveControllerUpDown mcUpDown;

    void Start()
    {
        //LeverHingeJoint = LeverJoint.GetComponent(typeof(HingeJoint)) as HingeJoint;
        //LeverHingeMotor = LeverHingeJoint.motor;
        MagnetJoint = MagnetHandle.GetComponent(typeof(SpringJoint)) as SpringJoint;
        CraneMovingSound = GetComponent(typeof(AudioSource)) as AudioSource;
        mcUpDown = UpDownTrigger.GetComponent(typeof(MoveControllerUpDown)) as MoveControllerUpDown;
        angle = 0;
        //JointLimits hingeJ = new JointLimits();
    }

    // Update is called once per frame
    // check horizontal input, move cab to left/right
    // check vertical input, move lever up/down
    // determine speeds of rotation
    // left arrow, right arrow, move
    // a,d rotate

    /*
     * not moving forward
     * arm up and down 
     * spinning cabin left and right
     * pulley up and down spring
     * 
     * ASTC
     * 
     * config rotation target
     * APK
     * Vallem, Unity VR Development, OLM 
     * 
     * set up spring for pulley mechanics, change limits
     * https://answers.unity.com/questions/278147/how-to-use-target-rotation-on-a-configurable-joint.html
     */

    public void MoveDown()
    {
        maxDistanceMagnet += 0.025f;
    }

    public void MoveUp()
    {
        if (maxDistanceMagnet > 0.3)
        {
            maxDistanceMagnet -= 0.0125f;
        }
    }

    void Update()
    {
        float rotateJointCabin = Input.GetAxis("Horizontal") * rotationSpeed * Time.timeScale;
        //float rotateJointLever = Input.GetAxis("Vertical") * rotationSpeed; //* rotationSpeed * 5;

        if ((rotateJointCabin != 0f) || (mcUpDown.UpDownMovement))
        {
            CraneMovingSound.Play();
            //UnityEngine.Debug.Log(mcUpDown.UpDownMovement);
        } else
        {
            CraneMovingSound.Pause();
        }
        //angle = rotateJointLever;

        if (Input.GetKey("q") && maxDistanceMagnet < 5)
        {
            //print("up arrow key is held down");
            MoveDown();
        }

        if (Input.GetKey("e") && maxDistanceMagnet > 0)
        {
            //print("down arrow key is held down");
            MoveUp();
        }

        CabinConfigJoint.transform.Rotate(0, rotateJointCabin, 0);

        /*
        hingeJ.min = angle;
        hingeJ.max = angle;
        LeverHingeJoint.limits = hingeJ;
        print(angle);
        */
        /*
        LeverHingeMotor.force += 40 * rotateJointLever;
        LeverHingeMotor.targetVelocity = 20 * Input.GetAxis("Vertical");

        LeverHingeJoint.useMotor = true;
        LeverHingeJoint.motor = LeverHingeMotor;
        */
        //LeverHingeJoint.transform.Rotate(rotateJointLever, 0, 0);
        MagnetJoint.maxDistance = maxDistanceMagnet;
    }
}
