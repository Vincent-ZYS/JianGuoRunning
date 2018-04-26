using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GuiController : MonoBehaviour {

    public RuntimeAnimatorController[] playerAnimatorController;
    public Animator playerImageAnimator;
    public Image AboutImage;

    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject choosePlayerUI;

    static public bool isLoad = false;
    private int aniGroupIndex = 0;
    private int aniGroupLength;


    void Start()
    {
        aniGroupLength = playerAnimatorController.Length;
        playerImageAnimator.runtimeAnimatorController = playerAnimatorController[aniGroupIndex];
    }

    private void Update()
    {

#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Vector2 TouchLoc = Input.GetTouch(0).position;
            TouchPhase TPhase = Input.GetTouch(0).phase;
            RaycastHit Hitinfo;
            if (TPhase.Equals(TouchPhase.Began))
            {
                Ray ray = Camera.main.ScreenPointToRay(TouchLoc);
                Physics.Raycast(ray, out Hitinfo);
                Hitinfo.collider.gameObject.SendMessage("OnMouseDown");
            }
        }
#endif

    }

    public void OnGoButtonDown(){
        switch (aniGroupIndex)
        {
            case 0:
                ChoosePlayer.instance.playerAnimatorController = "banana";
                break;
            case 1:
                ChoosePlayer.instance.playerAnimatorController = "leechee";
                break;
            default:
                Debug.LogError("aniGroupIndex Error");
                break;
        }
        
        SceneManager.LoadScene("GameScene");
    }

    public void OnRightButtonDown()
    {
        if (aniGroupIndex < aniGroupLength - 1)
            aniGroupIndex++;
        else
        {
            aniGroupIndex = 0;
        }
        ChangeImageAnimatorController();
    }

    public void OnLeftButtonDown()
    {
        if (aniGroupIndex <= 0)
            aniGroupIndex = aniGroupLength - 1;
        else
        {
            aniGroupIndex--;
        }
        ChangeImageAnimatorController();
    }

    public void OnAboutButtonDown()
    {
        AboutImage.gameObject.SetActive(true);
    }

    public void OnAboutCloseButtonDown()
    {
        AboutImage.gameObject.SetActive(false);
    }

    private void ChangeImageAnimatorController()
    {
        playerImageAnimator.runtimeAnimatorController = playerAnimatorController[aniGroupIndex];
    }

    public void OnStartButtonDown()
    {
        choosePlayerUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void OnBackToTileButtonDoen()
    {
        mainMenuUI.SetActive(true);
        choosePlayerUI.SetActive(false);
    }
}
