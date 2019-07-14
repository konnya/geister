using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Top : MonoBehaviour {

	private UserInfo info;

	private void UpdateTextInfo() {
		var textInfo = GameObject.Find("/Canvas/TextInfo");
		textInfo.transform.Find("Sucrifice").GetComponent<Text>().text = info.UserName();
	}

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

		UpdateTextInfo();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClickVsCpu() {
		Debug.Log($"Callback : {nameof(OnClickVsCpu)}");
		// SceneManager.LoadScene("MatchingScene");
		SceneManager.LoadScene("GameScene");
	}
	public void OnClickVsPlayer() {
		Debug.Log($"Callback : {nameof(OnClickVsPlayer)}");
		// SceneManager.LoadScene("MatchingScene");
	}
	public void OnClickVsOnline() {
		Debug.Log($"Callback : {nameof(OnClickVsOnline)}");
		// SceneManager.LoadScene("MatchingScene");
	}

	public void OnClickClearUserInfo() {
		info.Clear();
	}
}
