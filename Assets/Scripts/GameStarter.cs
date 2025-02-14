using UnityEngine;
/* 
 * 最初の準備でやること 
 * - 使わないボタンの非表示
*/
public class GameStarter : MonoBehaviour
{
    [SerializeField]
    GameObject _handButtons;
    [SerializeField]
    GameObject _settingModal;
    [SerializeField]
    GameObject _ponButton;

    // テスト用の依存関係を注入するメソッド
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

    // テスト内でStart()を実行するためのpublicなメソッド
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
