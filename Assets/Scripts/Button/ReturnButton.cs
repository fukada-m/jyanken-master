using UnityEngine;

public class ReturnButton : MonoBehaviour
{
    [SerializeField]
    GameObject modal;
    [SerializeField]
    GameObject menuButtons;
    [SerializeField]
    GameObject messageText;

    // テスト用の依存関係を注入するメソッド
    public void Initialize(GameObject m1, GameObject m2, GameObject m3)
    {
        modal = m1;
        menuButtons = m2;
        messageText = m3;
    }
    public void OnClickButton()
    {
        modal.SetActive(false);
        menuButtons.SetActive(true);
        messageText.SetActive(true);
    }
}
