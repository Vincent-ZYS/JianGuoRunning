using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamingGUIController : MonoBehaviour {

    public GameObject pauseMenuUI;
    public Text pauseMenuScoreText;

    public void OnPauseButtonDown()
    {
        Time.timeScale = 0;
        pauseMenuScoreText.text = "Score  :  " + GameControl.instance.score.ToString();
        pauseMenuUI.SetActive(true);
    }

    public void OnMainmenuButtonDown()
    {
        SceneManager.LoadScene(0);
    }

    public void OnRestartMenuButtonDown()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }

        SceneManager.LoadScene(1);
    }

    public void OnClosePauseButton()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
    }
}
