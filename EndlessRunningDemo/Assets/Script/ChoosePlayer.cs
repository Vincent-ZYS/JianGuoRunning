using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePlayer : MonoBehaviour {

    public string playerAnimatorController;
    static public bool isload = false;

	void Start () {
        if(!isload)
        {
            DontDestroyOnLoad(gameObject);
            isload = true;
        }

	}
	
}
