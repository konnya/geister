using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour {

	private UserInfo info;

	private GameObject canvas;

	private const float kPitch = 126.0f + 1.0f/3.0f;
	private const float kOriginX = -323.0f;
	private const float kOriginY = +360.0f;

	private List<GameObject> enemy = new List<GameObject>();

	// o ---> [0.0, ...]
	// |
	// v [0.0, ...]
	Vector3 Position(float x, float y) {
		return new Vector3(kOriginX + x, kOriginY + y, 0.0f);
	}

	Vector3 Position(int x, int y) {
		return Position(kPitch * x, kPitch * y);
	}

    // Algebraic Notation Position
	Vector3 ANPosition(int x, int y) {
		return Position(x, -y);
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
			Debug.LogAssertion("Can not get UserInfo.");
		}

		canvas = GameObject.Find("GameCanvas");

        Debug.Log("Start!!");
		GameObject prefab = (GameObject)Resources.Load ("Prefabs/EnemyGhost");
		for (int i = 1; i < 5;i ++) {
			for (int j = 0; j < 2;j ++) {
				Vector3 pos = prefab.transform.position + ANPosition(i, j);
				GameObject pc = Instantiate (prefab, pos, Quaternion.identity);
				pc.transform.SetParent(canvas.transform, false);
				enemy.Add(pc);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log$"Update : {nameof(OnClickVsCpu)}");
	}

}
