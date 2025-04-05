using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.SceneManagement;

public class PostRankingButton : MonoBehaviour
{
    [SerializeField]
    Ranking ranking;
    [SerializeField]
    DispRankingButton dispRakingButton;
    IObserver messageText;
    INotify messageNotify;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        messageText = GameObject.Find("MessageText").GetComponent<ObserverText>();
        messageNotify = new Notify();
        messageNotify.AddObserver(messageText);
    }

    public void OnClickButton()
    {
        ranking.PostRanking();
        messageNotify.SetTextNotify("�����L���O�o�^����!!\n���C�����j���[�Ɉړ����܂�");
        StartCoroutine(MoveTop());
    }

    IEnumerator MoveTop()
    {
        yield return new WaitForSeconds(1f);
        // �V�[�����ēǂݍ���
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}

