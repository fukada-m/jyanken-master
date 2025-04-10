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
    public bool Flag { get; set;}
    string userName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        messageText = GameObject.Find("MessageText").GetComponent<ObserverText>();
        messageNotify = new Notify();
        messageNotify.AddObserver(messageText);
        Flag = true;
    }

    public void OnClickButton()
    {
        if (Flag)
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
                ranking.PostRanking(Result.WinCount, userName, this);
                messageNotify.SetTextNotify("�����L���O�o�^��!!\n����������g�b�v�Ɉړ����܂�");
                Flag = false;
            }
            else if (userName.Length > 11)
            {
                messageNotify.SetTextNotify("�������G���[\n 10�����ȉ��ɂ��Ă�������");
            }
            
        }
    }

    public void DispPushAgain()
    {
        messageNotify.SetTextNotify("�o�^�Ɏ��s���܂����B\n�ēx���M�{�^���������Ă��������B");
    }
}

