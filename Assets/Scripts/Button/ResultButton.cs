using UnityEngine;

public class ResultButton : MonoBehaviour
{
    [SerializeField]
    GameObject resultButtonOBJ;
    [SerializeField]
    GameObject endButtonOBJ;
    [SerializeField]
    GameObject winCountTextOBJ;
    [SerializeField]
    GameObject againButtonOBJ;
    IObserver messageText;
    IObserver winCountText;
    INotify messageNotify;
    INotify winCountNotify;
    int winCount = 0;
    public virtual IResult Result { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        messageText = GameObject.Find("MessageText").GetComponent<ObserverText>();
        // WinCountText�͍ŏ���\���ɂȂ��Ă���̂�
        // �e�I�u�W�F�N�g��Canvas�����ǂ��Ď擾
        Transform parent = GameObject.Find("Canvas").transform;
        Transform child = parent.transform.Find("WinCountText");
        winCountTextOBJ = child.gameObject;
        winCountText = winCountTextOBJ.GetComponent<ObserverText>();
        messageNotify = new Notify();
        messageNotify.AddObserver(messageText);
        winCountNotify = new Notify();
        winCountNotify.AddObserver(winCountText);
    }

    //�e�X�g�p�̈ˑ��֌W�𒍓����郁�\�b�h
    public void Initialize(
        GameObject r1,
        GameObject e,
        GameObject w,
        GameObject a,
        INotify n1,
        INotify n2,
        IResult r2
    )
    {
        resultButtonOBJ =  r1;
        endButtonOBJ = e;
        winCountTextOBJ = w;
        againButtonOBJ = a;
        messageNotify = n1;
        winCountNotify = n2;
        Result = r2;
    }

    public void OnClickButton()
    {
        // �Ȃ����V�i���I�e�X�g�������notify��Null�ɂȂ邩�珈����ǉ�
        if (messageNotify == null)
        {
            Start();
        }
        messageNotify.SetTextNotify($"���ʂ�{Result.ConvertResultToJapanese()}�ł�");
        WinCountLogic();
        resultButtonOBJ.SetActive(false);
        endButtonOBJ.SetActive(true);
        winCountTextOBJ.SetActive(true);
        againButtonOBJ.SetActive(true);
    }

    void WinCountLogic()
    {
        if (Result.Current == Value.Result.Win) winCount++;
        if (Result.Current == Value.Result.Lose) winCount = 0;
        winCountNotify.SetTextNotify($"�A�����F{winCount}");
    }

}
