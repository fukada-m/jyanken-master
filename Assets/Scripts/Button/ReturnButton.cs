using UnityEngine;

public class ReturnButton : MonoBehaviour
{
    [SerializeField]
    GameObject settingModal;
    [SerializeField]
    GameObject menuButtons;
    [SerializeField]
    GameObject messageText;

    // �e�X�g�p�̈ˑ��֌W�𒍓����郁�\�b�h
    public void Initialize(GameObject s, GameObject m1, GameObject m2)
    {
        settingModal = s;
        menuButtons = m1;
        messageText = m2;
    }
    public void OnClickButton()
    {
        settingModal.SetActive(false);
        menuButtons.SetActive(true);
        messageText.SetActive(true);
    }
}
