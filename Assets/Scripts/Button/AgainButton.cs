using UnityEngine;

public class AgainButton : MonoBehaviour
{
    [SerializeField]
    GameObject handButtons;
    [SerializeField]
    GameObject againButtonOBJ;
    [SerializeField]
    GameObject endButtonOBJ;
    [SerializeField]
    GameObject checkRankingButtonOBJ;
    Notify messageNotify;
    Notify winCountNotify;
    IObserver messageText;
    IObserver winCountText;
    public virtual IResult Result { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        messageNotify = new Notify();
        messageNotify.AddObserver(messageText);
        // WinCountText�͍ŏ���\���ɂȂ��Ă���̂�
        // �e�I�u�W�F�N�g��Canvas�����ǂ��Ď擾
        Transform parent = GameObject.Find("Canvas").transform;
        Transform child = parent.transform.Find("WinCountText");
        var winCountTextOBJ = child.gameObject;
        winCountText = winCountTextOBJ.GetComponent<ObserverText>();
        winCountNotify = new Notify();
        winCountNotify.AddObserver(winCountText);
    }

    // �e�X�g�̈ˑ��֌W�𒍓����郁�\�b�h
    public void Initialize(GameObject h, GameObject a, GameObject e, Notify n)
    {
        handButtons = h;
        againButtonOBJ = a;
        endButtonOBJ = e;
        messageNotify = n;
    }

    public void OnClickButton()
    {

        // �n���h�{�^���Y��\��
        handButtons.SetActive(true);
        // ���g���\��
        againButtonOBJ.SetActive(false);
        // �G���h�{�^�����\��
        endButtonOBJ.SetActive(false);
        // �e�L�X�g���b�Z�[�W��"���̎���o�������߂Ă�������"�ɕύX
        messageNotify.SetTextNotify("���̎���o�������߂Ă�������");
        // ���O�ɕ����Ă����ꍇ�͘A������0�ɂ���
        if (Result.Current == Value.Result.Lose)
        {
            Result.WinCount = 0;
            winCountNotify.SetTextNotify($"�A�����F{Result.WinCount}");
        }
        // �����L���O�o�^�{�^���͔�\��
        checkRankingButtonOBJ.SetActive(false);
    }
}
