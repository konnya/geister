using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupUserInfo : MonoBehaviour {

	private UserInfo info;

	private GameObject nameInputModal;
	private InputField nameInput; 

	// Use this for initialization
	void Start () {
		// nameInput = GameObject.Find("/Canvas/NameInputModal/InputField").GetComponentInParent<InputField>();
		nameInputModal = GameObject.Find("/Canvas/NameInputModal");
		nameInput = nameInputModal.transform.Find("InputField").GetComponent<InputField>();
	
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

	public void OnClickSetName() {
		info.SetUserName(nameInput.text);
		Debug.LogFormat("Name is {0}", info.UserName());
	}
}