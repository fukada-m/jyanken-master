using UnityEngine;

public class OptionButton : MonoBehaviour
{
    [SerializeField]
    GameObject settingModal;
    [SerializeField]
    GameObject menuButtons;
    [SerializeField]
    GameObject rankingButton;
    [SerializeField]
    GameObject messageText;

    // �e�X�g�p�̈ˑ��֌W�𒍓����郁�\�b�h
    public void Initialize(GameObject s, GameObject m1,GameObject r, GameObject m2)
    {
        settingModal = s;
        menuButtons = m1;
        rankingButton = r;
        messageText = m2;
    }

    public void OnClickButton()
    {
        settingModal.SetActive(true);
        menuButtons.SetActive(false);
        messageText.SetActive(false);
        rankingButton.SetActive(false);
    }
}
