using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour {

	private string userName;
	private bool initialized = false;

	private const string initializedKey = "INITIALIZED";
	private const string userNameKey = "USER_NAME";

	public void Load() {
		userName = PlayerPrefs.GetString(userNameKey, "");

		if (PlayerPrefs.GetInt(initializedKey, 0) == 1) {
			initialized = true;
		} else {
			initialized = false;
		}

		Debug.Log("Load()");
		Debug.Log($" Initialized : {initialized}");
		Debug.Log($" UserName    : {userName}");
	}

	public void Clear() {
		PlayerPrefs.DeleteAll();
		Load();
	}

	// ref readonly is available when C# >= 7.2
	public bool IsInitialized() {
		return initialized;
	}

	public void MarkAsInitialized() {
		initialized = true;
		PlayerPrefs.SetInt(initializedKey, 1);
        PlayerPrefs.Save();
	}

	// ref readonly is available when C# >= 7.2
	public string UserName() {
		return userName;
	}

	public void SetUserName(string name) {
		userName = name;
		PlayerPrefs.SetString(userNameKey, userName);
	}

	void Awake() {
		Load();
	    DontDestroyOnLoad(this.gameObject);
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}