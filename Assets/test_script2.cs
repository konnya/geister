using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_script2 : MonoBehaviour {

	// Use this for initialization

    const int ghost_blue = 1; // 青アニメーション
    const int ghost_red = 2; // 赤アニメーション
	Animator animator;

	int count = 0;

	void Start () {
		Debug.Log("AAAAA");
		// animator = GetComponent<Animator>();
        // animator.SetInteger("judge", ghost_blue);
		Debug.Log(animator.name);
	}
	
	// Update is called once per frame
	void Update () {

		count++;
		if (count == 100) {
			Debug.Log("BLUE");
	    // animator.SetInteger("judge", ghost_blue);
		}
		if (count > 200) {
			Debug.Log("RED");
	    //    animator.SetInteger("judge", ghost_red);			
			count = 0;
		}
		
	}
}
