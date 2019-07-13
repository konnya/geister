using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAnimation : MonoBehaviour {

    // アニメーションタイプ
    const int ghost_blue = 1; // 青アニメーション
    const int ghost_red = 2; // 赤アニメーション

    // ゴーストタイプ
    const string GHOST_TYPE_BLUE = "good"; // 青ゴースト(良ゴースト)
    const string GHOST_TYPE_RED = "bad"; // 赤ゴースト(悪ゴースト)

    private GameObject _target_ghost;


    // 下記のゴーストタイプを受け取った前提
    string test_type = "good";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*
     * 敵ゴーストの結果アニメーション切り替え
     * @param target ゲームオブジェクト ゴースト
     */
    public void ghostResult(GameObject target)
    {
        _target_ghost = target;
        Animator animator = _target_ghost.GetComponent<Animator>();

        if (test_type == GHOST_TYPE_BLUE)
        {
            animator.SetInteger("judge", ghost_blue);
        }
        else if (test_type == GHOST_TYPE_RED)
        {
            animator.SetInteger("judge", ghost_red);
        }

    }

    /*
     * 自分ゴーストの出現アニメーション
     * @param target ゲームオブジェクト ゴースト
     */
    public void myGhostPop(GameObject target)
    {
        _target_ghost = target;
        Animator animator = _target_ghost.GetComponent<Animator>();

        if (test_type == GHOST_TYPE_BLUE)
        {
            animator.SetInteger("ghost_type", ghost_blue);
        }
        else if (test_type == GHOST_TYPE_RED)
        {
            animator.SetInteger("ghost_type", ghost_red);
        }
    }

    /*
     * 自分ゴーストの消えるアニメーション
     * @param target ゲームオブジェクト ゴースト
     */
    public void myGhostDisppear(GameObject target)
    {
        _target_ghost = target;
        Animator animator = _target_ghost.GetComponent<Animator>();

        if (test_type == GHOST_TYPE_BLUE)
        {
            animator.SetInteger("be_taken_piece", ghost_blue);
        }
        else if (test_type == GHOST_TYPE_RED)
        {
            animator.SetInteger("be_taken_piece", ghost_red);
        }
    }
}
