using UnityEngine;

public class ResultButton : MonoBehaviour
{
    [SerializeField]
    GameObject resultButtonOBJ;
    IObserver messageText;
    INotify notify;
    public virtual IResult Result { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        notify = new Notify();
        messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        notify.AddObserver(messageText);
    }

    //�e�X�g�p�̈ˑ��֌W�𒍓����郁�\�b�h
    public void Initialize(GameObject r1, INotify n, IResult r2)
    {
        resultButtonOBJ =  r1;
        notify = n;
        Result = r2;
    }

    public void OnClickButton()
    {
        notify.SetTextNotify($"���ʂ�{Result.ConvertResultToJapanese(Result.Current)}�ł�");
        resultButtonOBJ.SetActive(false);
    }

}
