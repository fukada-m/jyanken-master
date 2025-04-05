using UnityEngine;

public class CheckRankingButton : MonoBehaviour
{
    [SerializeField]
    Ranking ranking;
    [SerializeField]
    GameObject againButton;
    [SerializeField]
    GameObject endButton;
    [SerializeField]
    GameObject postRankingButton;
    [SerializeField]
    GameObject inputNameField;
    IObserver messageText;
    INotify messageNotify;
    PostRankingFlag postRankingFlag;
    public IResult Result {  get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        messageText = GameObject.Find("MessageText").GetComponent<ObserverText>();
        messageNotify = new Notify();
        messageNotify.AddObserver(messageText);
        postRankingFlag = new PostRankingFlag();
    }
    void Update()
    {
        // �t���O���I���̎��̓����L���O���X�V�\
        if (postRankingFlag.Flag ==2)
        {
            messageNotify.SetTextNotify("���߂łƂ�!! �����L���O���e�\");
            postRankingButton.SetActive(true);
            inputNameField.SetActive(true);
            postRankingFlag.Flag = 0;
        }
        if (postRankingFlag.Flag == 1)
        {
            messageNotify.SetTextNotify("����˂�B�����L���O�X�V�Ȃ炸");
            endButton.SetActive(true);
            againButton.SetActive(true);
            postRankingFlag .Flag = 0;
        }

    }

    public void OnclickButton()
    {
        messageNotify.SetTextNotify("�����L���O�Ɣ�r��...");
        ranking.CheckRanking(Result.WinCount, postRankingFlag);
        endButton.SetActive(false);
        againButton.SetActive(false);
    }
    
}

// 0�̓{�^�������O
// 1�̓����L���O�X�V�s��
// 2�̓����L���O�X�V�\
public class PostRankingFlag
{
    public int Flag { get; set; }
    public PostRankingFlag()
    {
        Flag = 0;
    }
}
