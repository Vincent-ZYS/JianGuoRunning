using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamingGUIController : MonoBehaviour {

    public void OnCloseButtonDown()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
