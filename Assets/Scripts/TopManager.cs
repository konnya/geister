using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopManager : MonoBehaviour {

    public GameObject Modal;
    public GameObject ModalBackground;
    public InputField InputUserNameField;
    public GameObject notice_text1;
    public GameObject notice_text2;
    public GameObject FixBtn;
    Sprite fix_on_btn;
    Sprite fix_off_btn;
    public GameObject UserDataManager;
    public GameObject winCount;
    public GameObject loseCount;
    public GameObject userName;

    // 入力されたユーザーネーム
    string input_user_name;

    // Use this for initialization
    void Start()
    {
        // ToDo 現在はスタートとかで呼び出すがのが推奨されてない。https://teratail.com/questions/45400
        fix_on_btn = Resources.Load<Sprite>("Img/common/buttom/bt_fix");
        fix_off_btn = Resources.Load<Sprite>("Img/common/buttom/bt_fix_of");
        // プライヤーデータマネージーにアクセス
        UserDataManager get_user_data = UserDataManager.GetComponent <UserDataManager> ();

        string username = get_user_data.GetMyname();
        if (string.IsNullOrEmpty(username))
        {
            // 名前未入力
            Modal.SetActive(true);
            ModalBackground.SetActive(true);
        }
        else {
            // 名前入力済
            int win_count = get_user_data.GetWinCount();
            int lose_count = get_user_data.GetLoseCount();
            winCount.GetComponent<Text>().text = win_count.ToString();
            loseCount.GetComponent<Text>().text = lose_count.ToString();
            userName.GetComponent<Text>().text = username;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    // ユーザーネームの取得
    public void EndEdit()
    {
        input_user_name = InputUserNameField.GetComponent<InputField>().text;
        Debug.Log(input_user_name);
        bool user_name_decision = CheckUserName(input_user_name);
        if (user_name_decision)
        {
            FixBtnOn();
            UserDataManager.GetComponent<UserDataManager>().SetMyname(input_user_name);
        }
        else
        {
            FixBtnOff();
        }
    }

    // ユーザーネームの正当性チェック
    private bool CheckUserName(string user_name)
    {
        bool check_result = true;
        // 空判定
        if (string.IsNullOrEmpty(user_name))
        {
            check_result = false;
            return check_result;
        }

        // 5文字判定
        int name_length = user_name.Length;
        if (name_length > 5)
        {
            check_result = false;
            return check_result;
        }

        // 漢字判定
        if (System.Text.RegularExpressions.Regex.IsMatch(user_name,
            @"[\p{IsCJKUnifiedIdeographs}" +
            @"\p{IsCJKCompatibilityIdeographs}" +
            @"\p{IsCJKUnifiedIdeographsExtensionA}]|" +
            @"[\uD840-\uD869][\uDC00-\uDFFF]|\uD869[\uDC00-\uDEDF]"))
        {
            check_result = false;
            return check_result;
        }

        return check_result;
    }

    // 決定ボタン画像変(on)
    private void FixBtnOn()
    {
        FixBtn.GetComponent<Image>().sprite = fix_on_btn;
    }

    // 決定ボタン画像変更(off)
    private void FixBtnOff()
    {
        FixBtn.GetComponent<Image>().sprite = fix_off_btn;
    }

    // 決定ボタン押下時処理
    public void FixBtnClick()
    {
        Sprite fix_btn_type = FixBtn.GetComponent<Image>().sprite;
        if (fix_btn_type == fix_on_btn) {
            Debug.Log("ok");
            UserDataManager.GetComponent<UserDataManager>().SetMyname(input_user_name);
            userName.GetComponent<Text>().text = input_user_name;
            Modal.SetActive(false);
            ModalBackground.SetActive(false);
        } else {
            Debug.Log("ng");
            ErrInputUsername ();
        }
    }

    public void ErrInputUsername()
    {
        notice_text1.GetComponent<Text>().color = new Color(1f, 1f, 0f, 1);
        notice_text2.GetComponent<Text>().color = new Color(1f, 1f, 0f, 1);
    }

    // 名前削除
    public void MynameDelete()
    {
        UserDataManager.GetComponent<UserDataManager>().DeleteMyname();
        Modal.SetActive(true);
        ModalBackground.SetActive(true);
    }

    // バトルボタン押下時処理
    public void BtnBattleClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
