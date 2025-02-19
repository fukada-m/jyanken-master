using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;


public class ButtonsTest
{
    GameObject _menuButtonsObj;
    GameObject _startButtonObj;
    StartButton _startButton;
    GameObject _optionButtonObj;
    OptionButton _optionButton;
    GameObject _handButtons;
    GameObject _settingModal;
    GameObject _returnButtonObj;
    ReturnButton _returnButton;
    GameObject _messageText;
    IObserver _observerText;

    [UnitySetUp]
    public IEnumerator ButtonsTestSetUp()
    {
        SceneManager.LoadScene("JyankenScene");
        yield return null;

        _menuButtonsObj = GameObject.Find("MenuButtons");
        Assert.IsNotNull( _menuButtonsObj);
    }

    [UnityTest]
    public IEnumerator OnClickOption_ShowSettingModalAndReturn()
    {
        yield return null;

        // falseになっているGameObjectも含めて取得する
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        _settingModal = objects.FirstOrDefault(o => o.name == "SettingModal");
        Assert.IsNotNull(_settingModal);

        _messageText = GameObject.Find("MessageText");
        Assert.IsTrue(_messageText);

        _returnButtonObj = objects.FirstOrDefault(o => o.name == "ReturnButton");
        Assert.IsNotNull(_returnButtonObj);
        _returnButton = _returnButtonObj.GetComponent<ReturnButton>();
        Assert.IsNotNull(_returnButton);
        Assert.IsTrue(CheckOnclickButton(_returnButtonObj));


        _optionButtonObj = GameObject.Find("OptionButton");
        Assert.IsNotNull(_optionButtonObj);
        _optionButton = _optionButtonObj.GetComponent<OptionButton>();
        Assert.IsNotNull(_optionButton);
        Assert.IsTrue(CheckOnclickButton(_optionButtonObj));

        // 初期状態ではMenuButtonsは表示、設定モーダルは非表示
        Assert.IsTrue(_menuButtonsObj.activeSelf);
        Assert.IsFalse(_settingModal.activeSelf);

        // オプションボタンをクリックすると設定モーダルと戻るボタンが表示され、
        // MenuButtonsとMessageTextは非表示になる
        _optionButton.OnClickButton();
        Assert.IsTrue(_settingModal.activeSelf);
        Assert.IsFalse(_menuButtonsObj.activeSelf);
        Assert.IsFalse(_messageText.activeSelf);

        // 戻るボタンをクリックすると再び設定モーダルは非表示になり、
        // MenuButtonsとMessageTextが表示される
        _returnButton.OnClickButton();
        Assert.IsFalse(_settingModal.activeSelf);
        Assert.IsTrue(_menuButtonsObj.activeSelf);
        Assert.IsTrue(_messageText.activeSelf);
    }
    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator onClickStartButton_ShowHandButton()
    {
        yield return null;

        // falseになっているHandButtonsを取得する
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        _handButtons = objects.FirstOrDefault(o => o.name == "HandButtons");
        Assert.IsFalse(_handButtons.activeSelf);
        _startButtonObj = GameObject.Find("StartButton");
        Assert.IsNotNull(_startButtonObj);
        _startButton = _startButtonObj.GetComponent<StartButton>();
        Assert.IsNotNull(_startButton);
        Assert.IsTrue(CheckOnclickButton(_startButtonObj));
        // スタートボタンをクリックするとメッセージが表示される
        // HandButtonsが表示される
        // MenuButtonsは非表示になる。
        _startButton.OnClickButton();
        _observerText = GameObject.Find("MessageText").GetComponent<IObserver>();
        Assert.AreEqual(_observerText.GetText(), "何の手を出すか決めてください");
        Assert.IsTrue(_handButtons.activeSelf);
        Assert.IsFalse(_menuButtonsObj.activeSelf);

    }

    // 送られてきたGameObjectのボタンコンポーネントに、
    // OnClickButtonがセットされているか確認する
    bool CheckOnclickButton(GameObject g)
    {
        var button = g.GetComponent<Button>();
        return (button.onClick.GetPersistentMethodName(0) == "OnClickButton");
    }
}
