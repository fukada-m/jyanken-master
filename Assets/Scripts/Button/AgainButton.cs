using UnityEngine;

public class AgainButton : MonoBehaviour
{
    [SerializeField]
    GameObject handButtons;
    [SerializeField]
    GameObject againButtonOBJ;
    [SerializeField]
    GameObject endButtonOBJ;
    Notify notify;
    IObserver messageText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        notify = new Notify();
        messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        notify.AddObserver(messageText);
    }

    // �e�X�g�̈ˑ��֌W�𒍓����郁�\�b�h
    public void Initialize(GameObject h, GameObject a, GameObject e, Notify n)
    {
        handButtons = h;
        againButtonOBJ = a;
        endButtonOBJ = e;
        notify = n;
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
        notify.SetTextNotify("���̎���o�������߂Ă�������");
    }
}
