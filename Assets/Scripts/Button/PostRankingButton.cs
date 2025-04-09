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
            // ��������10�����ȉ�
            if (userName.Length == 0)
            {
                messageNotify.SetTextNotify("�o�^�G���[\n���[�}����1�����ȏ�ɂ��Ă�������");
            }
            else if (userName.Length <= 10)
            {
                ranking.PostRanking(Result.WinCount, userName);
                messageNotify.SetTextNotify("�����L���O�o�^��!!\n����������g�b�v�Ɉړ����܂�");
                flag = false;
            }
            else if (userName.Length > 11)
            {
                messageNotify.SetTextNotify("�������G���[\n 10�����ȉ��ɂ��Ă�������");
            }
            
        }
    }
}

