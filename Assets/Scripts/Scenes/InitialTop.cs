﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InitialTop : MonoBehaviour {

	private UserInfo info;

	// Use this for initialization
	void Start () {
		// FIXME:Takara.Kasai
		// If this script is dispatched without instantiate application scope objects,
		// then following Find method will return null.
		GameObject obj = GameObject.Find("UserInfo");
		if (obj) {
			info = GameObject.Find("UserInfo").GetComponent<UserInfo>();
		} else {
			// Just create dummy UserInfo class to avoid exception in this script.
			Debug.LogWarning("Can not get UserInfo.");
			info = new UserInfo();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClickBecome() {
		Debug.Log($"Callback : {nameof(OnClickBecome)}");
		SceneManager.LoadScene("SetupUserInfo");
	}
}
