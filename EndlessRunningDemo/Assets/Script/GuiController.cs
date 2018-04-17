using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiController : MonoBehaviour {

    public void OnStartButtonDown(){
        SceneManager.LoadScene("TestScene");
    }
}
