using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalTrigger : MonoBehaviour
{

    public GameObject load;
    public Text scoreText;
    private int currentScore;
    private Transform initLoadPos;

    private void Start()
    {
        load = GameObject.FindWithTag("Load");
        currentScore = 0;
        scoreText.text = "Score: " + currentScore.ToString();
        initLoadPos = load.transform;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Load"))
        {
            currentScore += 1;
            StartCoroutine(WaitABit());
            scoreText.text = "Score: " + currentScore.ToString();
            load.transform.position = initLoadPos.position;
            load.transform.rotation = initLoadPos.rotation;
        }
    }

    IEnumerator WaitABit()
    {
        yield return new WaitForSeconds(1);
    }
}
