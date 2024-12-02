using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject title;
    public GameObject start;
    public GameObject end;
    public GameObject intructButton;
    public GameObject instructionText;
    public GameObject back;

    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void OnInstructionButton()
    {
        title.SetActive(false);
        start.SetActive(false); 
        end.SetActive(false);
        intructButton.SetActive(false);
        instructionText.SetActive(true);
        back.SetActive(true);
    }

    public void OnBackButton()
    {
        title.SetActive(true);
        start.SetActive(true);
        end.SetActive(true);
        intructButton.SetActive(true);
        instructionText.SetActive(false);
        back.SetActive(false);
    }


}
