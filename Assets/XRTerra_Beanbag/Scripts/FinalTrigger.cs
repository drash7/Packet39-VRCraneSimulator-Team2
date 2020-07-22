using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class FinalTrigger : MonoBehaviour
{

    public GameObject load;
    public Text scoreText;
    private int currentScore;
    private Transform initLoadPos;
    private Vector3 changePos;
    // add endCanvas, set to inactive
    // public Canvas endCanvas;

    private void Start()
    {
        load = GameObject.FindWithTag("Load");
        currentScore = 0;
        scoreText.text = "Score: " + currentScore.ToString();
        initLoadPos = load.transform;
        changePos = load.transform.position;
    }

    private void Update()
    {
        if (currentScore == 5)
        {
            // endCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Load"))
        {
            currentScore += 1;
            UnityEngine.Debug.Log("Current position upon collision: " + load.transform.position);
            StartCoroutine(WaitABit());
            scoreText.text = "Score: " + currentScore.ToString();
            load.transform.position = changePos;
            UnityEngine.Debug.Log("Current position after collision: " + load.transform.position);
            load.transform.rotation = initLoadPos.rotation;
        }
    }

    IEnumerator WaitABit()
    {
        yield return new WaitForSeconds(1);
    }
}
