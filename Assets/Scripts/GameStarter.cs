using UnityEngine;
using UnityEngine.XR;
/* 
 * �ŏ��̏����ł�邱�� 
 * - �g��Ȃ��{�^���̔�\��
 * - �I�u�U�[�o�[�̃Z�b�g
 */

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    GameObject _handButtons;
    [SerializeField]
    GameObject _settingModal;
    [SerializeField]
    GameObject _ponButton;
    [SerializeField]
    GameObject _observerTextObject;
    [SerializeField]
    StartButton _startButton;
    IHand _hand;
    IObserver _observerText;

    // �e�X�g�p�̈ˑ��֌W�𒍓����郁�\�b�h
    public void TestInitialize(
        GameObject handButtons,
        GameObject settingModal,
        GameObject ponButton,
        GameObject startButton,
        GameObject observerTextObject,
        IHand hand,
        IObserver observerText
     )
    {
        _handButtons = handButtons;
        _settingModal = settingModal;
        _ponButton = ponButton;
        // TODO startButton��mock�����
        //_startButton = startButton;
        _observerTextObject = observerTextObject;
        _hand = hand;
        _observerText = observerText;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _hand = _handButtons.GetComponent<IHand>();
        _observerText = _observerTextObject.GetComponent<IObserver>();
        HideObject();
        SetObserver();
    }

    void HideObject()
    {
        _handButtons.SetActive(false);
        _settingModal.SetActive(false);
        _ponButton.SetActive(false);
    }
    void SetObserver()
    {
        _hand.AddObserver(_observerText);
        _startButton.AddObserver(_observerText);
    }
}
