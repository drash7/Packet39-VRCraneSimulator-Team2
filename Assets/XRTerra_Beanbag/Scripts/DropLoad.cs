using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoad : MonoBehaviour
{

    private CraneMagnet craneMagnetObject;
    // Start is called before the first frame update
    void Start()
    {
        craneMagnetObject = new CraneMagnet();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("DropTrigger"))
        {
            craneMagnetObject.DropObject();
        }
    }
}
