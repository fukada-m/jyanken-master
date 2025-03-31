using UnityEngine;

public class ReturnButton : MonoBehaviour
{
    [SerializeField]
    GameObject settingModal;
    [SerializeField]
    GameObject menuButtons;
    [SerializeField]
    GameObject messageText;
    [SerializeField]
    GameObject rankingButton;

    // テスト用の依存関係を注入するメソッド
    public void Initialize(GameObject s, GameObject m1, GameObject m2, GameObject r)
    {
        settingModal = s;
        menuButtons = m1;
        messageText = m2;
        rankingButton = r;
    }
    public void OnClickButton()
    {
        settingModal.SetActive(false);
        menuButtons.SetActive(true);
        messageText.SetActive(true);
        rankingButton.SetActive(true);
    }
}
