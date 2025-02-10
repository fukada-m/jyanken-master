using UnityEngine;
using UnityEngine.XR;
/* 
 * 最初の準備でやること 
 * - 使わないボタンの非表示
 * - オブザーバーのセット
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

    // テスト用の依存関係を注入するメソッド
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
        // TODO startButtonのmockを作る
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
