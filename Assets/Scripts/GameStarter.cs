using UnityEngine;
/* 
 * �ŏ��̏����ł�邱�� 
 * - �g��Ȃ��{�^���̔�\��
*/
public class GameStarter : MonoBehaviour
{
    [SerializeField]
    GameObject _handButtons;
    [SerializeField]
    GameObject _settingModal;
    [SerializeField]
    GameObject _ponButton;

    // �e�X�g�p�̈ˑ��֌W�𒍓����郁�\�b�h
    public void Initialize(
        GameObject handButtons,
        GameObject settingModal,
        GameObject ponButton
     )
    {
        _handButtons = handButtons;
        _settingModal = settingModal;
        _ponButton = ponButton;
    }

    // �e�X�g����Start()�����s���邽�߂�public�ȃ��\�b�h
    public void TestStart()
    {
        Start();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HideObject();
    }

    void HideObject()
    {
        _handButtons.SetActive(false);
        _settingModal.SetActive(false);
        _ponButton.SetActive(false);
    }
}
