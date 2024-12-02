using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    public GameObject winZone;
    public GameObject player;
    private AudioSource music;
    public GameObject[] idols = new GameObject[12];
    private bool isPaused = false;

    public int idolTotalCollected;
    public Text pauseText;
    public Text timerText;
    public GameObject deadText;

    private int timeLeft;


    // Start is called before the first frame update
    void Start()
    {
        TimerStart();
        timerText.text = "Time Left: " + timeLeft.ToString();
        music = player.GetComponent<AudioSource>();
        StartCoroutine(timerRoutine());
        winZone.SetActive(false);
        IdolActivate();
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
            StopCoroutine(timerRoutine());
        }
        else if(isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
            StartCoroutine(timerRoutine());
        }
        timeLoose();
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

    public void IdolActivate()
    {
        int idolOne = UnityEngine.Random.Range(0, 11);
        int idolTwo = UnityEngine.Random.Range(0, 11);
        int idolThree = UnityEngine.Random.Range(0, 11);

        while(idolTwo == idolOne) 
        {
            idolTwo = UnityEngine.Random.Range(0, 11);
        }

        while((idolThree == idolOne) || (idolThree == idolTwo))
        {
            idolThree = UnityEngine.Random.Range(0, 11);
        }

        idols[idolOne].SetActive(true);
        idols[idolTwo].SetActive(true);
        idols[idolThree].SetActive(true);
    }

    private void TimerStart()
    {
        timeLeft = 400;
    }

    private IEnumerator timerRoutine()
    {
        while (timeLeft > 0 && !isPaused)
        {
            yield return new WaitForSecondsRealtime(1);
            timeLeft--;
            timerText.text = "Time Left: " + timeLeft.ToString();
        }
        
    }

    private void timeLoose()
    {
        if(timeLeft == 0)
        {
            Time.timeScale = 0;
            music.Stop();
            deadText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }



}
