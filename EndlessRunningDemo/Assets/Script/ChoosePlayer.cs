using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePlayer : MonoBehaviour {

    public string playerAnimatorController;

	void Start () {
        GameObject.DontDestroyOnLoad(gameObject);
	}
	
}
