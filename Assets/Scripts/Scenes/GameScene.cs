using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameScene : MonoBehaviour {

	private int kNumOfRows = 6;
	private int kNumOfColumns = 6;
	private float kPitchX;
	private float kPitchY;
	private float kOriginX;
	private float kOriginY;

	private UserInfo info;

	private GameObject canvas;
	private Graphic graphic;
	
	private List<GameObject> enemy = new List<GameObject>();
	private List<GameObject> friend = new List<GameObject>();
	private List<GameObject> pieces = new List<GameObject>();

	// o ---> [0.0, ...]
	// |
	// v [0.0, ...]
	Vector2Int Position2AN(Vector3 pos) {
		var x = (pos.x - kOriginX) / kPitchX;
		var y = (pos.y - kOriginY) / kPitchY;
		x = +x + 0.5f;
		y = -y + 0.5f;
		return new Vector2Int((int)(Mathf.Floor(x)), (int)(Mathf.Floor(y)));
	}

	Vector3 Position(float x, float y) {
		return new Vector3(kOriginX + x, kOriginY + y, 0.0f);
	}

	Vector3 Position(int x, int y) {
		return Position(kPitchX * x, kPitchY * y);
	}

    // Algebraic Notation Position
	Vector3 ANPosition(int x, int y) {
		return Position(x, -y);
	}

	GameObject Instantiate(GameObject prefab, int x, int y) {
		Vector3 pos = prefab.transform.position + ANPosition(x, y);
		Debug.Log($"Instantiate : {pos}");

		GameObject pc = Instantiate (prefab, pos, Quaternion.identity);
		pc.transform.SetParent(canvas.transform, false);
		return pc;
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
		// "BoardImg" can be also used.
		graphic = GameObject.Find("GameCanvas/BoardImg").GetComponent<Graphic>();

		kPitchX  = graphic.rectTransform.sizeDelta.x / kNumOfColumns;
		kPitchY  = graphic.rectTransform.sizeDelta.y / kNumOfRows;
		kOriginX = -kPitchX * 5.0f / 2.0f;
		kOriginY = +kPitchY * 5.0f / 2.0f;
		Debug.Log($"Size : {kPitchX} {kPitchY} : {kOriginX} {kOriginY}");
		
        Debug.Log("Start!!");
		GameObject prefab_enemy = (GameObject)Resources.Load ("Prefabs/EnemyGhost");
		GameObject prefab_friend = (GameObject)Resources.Load ("Prefabs/FriendGhost");
		for (int i = 1; i < 5;i ++) {
			for (int j = 0; j < 2;j ++) {
				GameObject pc = Instantiate(prefab_enemy, i, j);
				enemy.Add(pc);

				pc = Instantiate(prefab_friend, i, j + 4);
				friend.Add(pc);
				pc.GetComponent<Animator>().SetInteger("Color", j == 1 ? 0 : 1);

				pieces.Add(pc);
			}
		}

		foreach (GameObject pc in enemy.Concat(friend)) {
			pc.GetComponent<Animator>().SetTrigger("Pop");
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log$"Update : {nameof(OnClickVsCpu)}");
	}

	public void OnPointerClick(){
		Debug.Log($"OnPointerClick : {canvas.transform.position}, {Input.mousePosition}");

		// convert coordinates from screen's one to canvas's one
		Vector2 pos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(
			graphic.rectTransform, Input.mousePosition, Camera.main, out pos);
		
		var an = Position2AN(pos);
		Debug.Log($"OnPointerClick : {pos} --> {an}");

		return;
	}

}
