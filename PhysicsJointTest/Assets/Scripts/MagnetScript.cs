using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Magnet;
    private void Update()
    {
        Magnet.layer = gameObject.layer;
    }
}
