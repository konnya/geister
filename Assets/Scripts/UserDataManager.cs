using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : MonoBehaviour {

	// Use is for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
		
    }

    // プレイヤーネームを設定
    public void SetMyname(string name)
    {
        PlayerPrefs.SetString("USER_NAME", name);
        PlayerPrefs.Save();
    }

    // プレイヤーネーム削除
    public void DeleteMyname ()
    {
        PlayerPrefs.DeleteKey("USER_NAME");
    }

    // プレイヤーネームを取得
    public string GetMyname()
    {
        string user_name = PlayerPrefs.GetString("USER_NAME");
        return user_name;
    }

    // 勝利数を更新
    public void SetWinCount(int win_count)
    {
        PlayerPrefs.SetInt("USER_WIN", win_count);
        PlayerPrefs.Save();
    }

    // 勝利数を取得
    public int GetWinCount()
    {
        int win_count = 0;
        return win_count;
    }

    // 敗北数を更新
    public void SetLoseCount(int lose_count)
    {
        PlayerPrefs.SetInt("USER_LOSE", lose_count);
        PlayerPrefs.Save();
    }

    // 敗北数を取得
    public int GetLoseCount()
    {
        int lose_count = 0;
        return lose_count;
    }

}
