using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update

    public bool paused;
    public GameObject StartCanvas;
    public GameObject Restart;
    void Start()
    {
        paused = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            Paused();
        } else
        {
            Unpaused();
        }
    }
    public void Paused()
    {
        Time.timeScale = 0;
        StartCanvas.SetActive(true);
        Restart.SetActive(true);
        paused = true;
    }

    public void Unpaused()
    {
        Time.timeScale = 1;
        StartCanvas.SetActive(false);
        Restart.SetActive(false);
        paused = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
