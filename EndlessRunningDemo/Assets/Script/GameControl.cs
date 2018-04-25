using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public bool isOver = false;
    public float Volume;
    public GameObject gameOverText;
    public static GameControl instance;
    public Text scoreText;
    public float scrollSpeed = -1.5f;
    public float spawnRate = 4.0f;
    public Animator anim;
    public Rigidbody2D rgbd;
    public RuntimeAnimatorController[] playerAnimatorController;

    private ChoosePlayer choosePlayer;
    private int score;
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
            choosePlayer = FindObjectOfType<ChoosePlayer>().GetComponent<ChoosePlayer>();
        switch (choosePlayer.playerAnimatorController)
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

        deviceName = Microphone.devices[0];
        micRecord = Microphone.Start(deviceName, true, 999, 44100);
	}

	// Update is called once per frame
	void Update () {
        if(isOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }else if(isOver == false)
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
        
        gameOverText.SetActive(true);
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
