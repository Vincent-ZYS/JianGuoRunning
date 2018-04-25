using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public bool isOver = false;
    public float Volume;
    public GameObject gameOverMenu;
    public static GameControl instance;
    public Text scoreText;
    public Text gameOverMenuScoreText;
    public float scrollSpeed = -1.5f;
    public float spawnRate = 4.0f;
    public Animator anim;
    public Rigidbody2D rgbd;
    public RuntimeAnimatorController[] playerAnimatorController;
    public int score;


    private string deviceName;
    private AudioClip micRecord;
    private float timer;

	void Awake () {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(this);
        }
	}

	void Start()
	{
        if(Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }

        if(ChoosePlayer.instance == null)
        {
            anim.runtimeAnimatorController = playerAnimatorController[0];
            Debug.Log("ChoosePlayer.instance is null");
        }
        else
        {
            switch (ChoosePlayer.instance.playerAnimatorController)
            {
                case "banana":
                    anim.runtimeAnimatorController = playerAnimatorController[0];
                    break;
                case "leechee":
                    anim.runtimeAnimatorController = playerAnimatorController[1];
                    break;
                default:
                    anim.runtimeAnimatorController = playerAnimatorController[0];
                    Debug.Log("choosePlayer.playerAnimatorController String Error");
                    break;
            }
        }

        deviceName = Microphone.devices[0];
        micRecord = Microphone.Start(deviceName, true, 999, 44100);
	}

	// Update is called once per frame
	void Update () {
        if(isOver == false)
        {
            timer += Time.deltaTime;
            Volume = MaxVolume();
        }
	}

    public void PlayerScore()
    {
        if(isOver == true)
        {
            return;
        }
        score = -1*(int)(timer * scrollSpeed *10);
        scoreText.text = "Score:" + score.ToString();
    }

    public void PlayerDie()
    {
        gameOverMenu.SetActive(true);
        gameOverMenuScoreText.text = "Score  :  " + score.ToString();
        isOver = true;
    }

    public float MaxVolume()
    {
        float maxVolume = 0;
        float[] volumeData = new float[128];
        int offset = Microphone.GetPosition(deviceName) - 128 + 1;
        if(offset < 0)
        {
            return 0;
        }

        micRecord.GetData(volumeData, offset);

        for (int i = 0; i < volumeData.Length; i++)
        {
            float tempVolume = volumeData[i] * 1.5f;

            if(maxVolume < tempVolume)
            {
                maxVolume = tempVolume;
            }
        }
        return maxVolume;
    }
}
