using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresController : Singleton<ScoresController>
{

    public Text scoreText;
    private int currentScore;
    public GameObject loadPrefab;
    public GameObject load;
    private Transform initLoadPos;

    void Start()
    {
        currentScore = 0;
        initLoadPos = load.transform;
        load = GameObject.FindWithTag("Load");
    }

    public void addScore()
    {
        currentScore += 1;
        scoreText.text = "Score: " + currentScore.ToString();
        // Destroy(load);
    }

    public void respawnLoad()
    {
        load.transform.position = initLoadPos.position;
    }
}
