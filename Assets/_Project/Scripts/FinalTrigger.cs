using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTrigger : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Load"))
        {
            ScoresController.Instance.addScore();
            ScoresController.Instance.respawnLoad();
        }
    }
}
