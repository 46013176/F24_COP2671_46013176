using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public GameObject winZone;
    public GameObject player;
    private bool isPaused = false;

    public int idolTotalCollected;
    public Text pauseText;


    // Start is called before the first frame update
    void Start()
    {
        winZone.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        idolTotalCollected = player.GetComponent<PlayerController>().idolTotal;

        if (idolTotalCollected == 0)
        {
            winZone.SetActive(true);
        }

        if(!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        else if(isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseText.gameObject.SetActive(true);
        player.GetComponent<AudioSource>().Pause();
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseText.gameObject.SetActive(false);
        player.GetComponent<AudioSource>().Play();
        isPaused = false;
    }



}
