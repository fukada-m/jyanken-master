using UnityEngine;

public class ResultButton : MonoBehaviour
{
    [SerializeField]
    GameObject resultButtonOBJ;
    [SerializeField]
    GameObject endButtonOBJ;
    [SerializeField]
    GameObject winCountTextOBJ;
    IObserver messageText;
    INotify notify;
    public virtual IResult Result { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        notify = new Notify();
        notify.AddObserver(messageText);
    }

    //�e�X�g�p�̈ˑ��֌W�𒍓����郁�\�b�h
    public void Initialize(
        GameObject r1,
        GameObject e,
        GameObject w,
        INotify n,
        IResult r2
    )
    {
        resultButtonOBJ =  r1;
        endButtonOBJ = e;
        winCountTextOBJ = w;
        notify = n;
        Result = r2;
    }

    public void OnClickButton()
    {
        // �Ȃ����V�i���I�e�X�g�������notify��Null�ɂȂ邩�珈����ǉ�
        if (notify == null)
        {
            Start();
        }
        notify.SetTextNotify($"���ʂ�{Result.ConvertResultToJapanese()}�ł�");
        resultButtonOBJ.SetActive(false);
        endButtonOBJ.SetActive(true);
        winCountTextOBJ.SetActive(true);
    }

}
