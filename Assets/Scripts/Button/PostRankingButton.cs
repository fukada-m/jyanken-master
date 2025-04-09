using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class PostRankingButton : MonoBehaviour
{
    [SerializeField]
    Ranking ranking;
    [SerializeField]
    DispRankingButton dispRakingButton;
    [SerializeField]
    TMP_InputField inputField;
    IObserver messageText;
    INotify messageNotify;
    public IResult Result { get; set; }
    string userName;
    bool flag;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        messageText = GameObject.Find("MessageText").GetComponent<ObserverText>();
        messageNotify = new Notify();
        messageNotify.AddObserver(messageText);
        flag = true;
    }

    public void OnClickButton()
    {
        if (flag)
        {
            userName = inputField.text;
            Debug.Log("userName:" + userName);
            // 文字数が10文字以下
            if (userName.Length == 0)
            {
                messageNotify.SetTextNotify("登録エラー\nローマ字で1文字以上にしてください");
            }
            else if (userName.Length <= 10)
            {
                ranking.PostRanking(Result.WinCount, userName);
                messageNotify.SetTextNotify("ランキング登録中!!\n完了したらトップに移動します");
                flag = false;
            }
            else if (userName.Length > 11)
            {
                messageNotify.SetTextNotify("文字数エラー\n 10文字以下にしてください");
            }
            
        }
    }
}

