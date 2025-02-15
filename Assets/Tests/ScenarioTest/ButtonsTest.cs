using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;


public class ButtonsTest
{
    GameStarter _gameStarter;
    GameObject _menuButtonsObj;
    GameObject _startButtonObj;
    StartButton _startButton;
    GameObject _optionButtonObj;
    OptionButton _optionButton;
    GameObject _handButtonsObj;
    HandButtons _handButtons;
    GameObject _settingModal;
    GameObject _returnButtonObj;
    ReturnButton _returnButton;
    GameObject _ponButtonObj;
    PonButton _ponButton;
    GameObject _observerTextObj;
    ObserverText _observerText;
    Notify _start;
    ISign Sign;

    [UnitySetUp]
    public IEnumerator ButtonsTestSetUp()
    {
        SceneManager.LoadScene("JyankenScene");
        yield return null;

        //_handButtonsObj = GameObject.Find("HandButtons");
        //_handButtons = _handButtonsObj.GetComponent<HandButtons>();
        //_observerTextObj = GameObject.Find("ObserverText");
        //_observerText = _observerTextObj.GetComponent<ObserverText>();
        //_ponButtonObj = GameObject.Find("PonButton");
        //_ponButton = _ponButtonObj.GetComponent<PonButton>();
        
    }

    [UnityTest]
    public IEnumerator OnClickOption_ShowSettingModalAndReturn()
    {
        yield return null;

        // falseになっているGameObjectも含めて取得する
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        _settingModal = objects.FirstOrDefault(o => o.name == "SettingModal");
        Assert.IsNotNull(_settingModal);

        _returnButtonObj = objects.FirstOrDefault(o => o.name == "ReturnButton");
        Assert.IsNotNull(_returnButtonObj);
        _returnButton = _returnButtonObj.GetComponent<ReturnButton>();
        Assert.IsNotNull(_returnButton);
        Assert.IsTrue(CheckOnclickButton(_returnButtonObj));

        _menuButtonsObj = GameObject.Find("MenuButtons");
        Assert.IsNotNull( _menuButtonsObj);

        _optionButtonObj = GameObject.Find("OptionButton");
        Assert.IsNotNull(_optionButtonObj);
        _optionButton = _optionButtonObj.GetComponent<OptionButton>();
        Assert.IsNotNull(_optionButton);
        Assert.IsTrue(CheckOnclickButton(_optionButtonObj));

        // 初期状態ではMenuButtonsは表示、設定モーダルは非表示
        Assert.IsTrue(_menuButtonsObj.activeSelf);
        Assert.IsFalse(_settingModal.activeSelf);

        // オプションボタンをクリックすると設定モーダルと戻るボタンが表示され、
        // MenuButtonsは非表示になる
        _optionButton.OnClickButton();
        Assert.IsTrue(_settingModal.activeSelf);
        Assert.IsFalse( _menuButtonsObj.activeSelf);

        // 戻るボタンをクリックすると再び設定モーダルは非表示になり、
        // MenuButtonsが表示される
        _returnButton.OnClickButton();
        Assert.IsFalse(_settingModal.activeSelf);
        Assert.IsTrue(_menuButtonsObj);



    }
    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator onClickStartButton_ShowHandButton()
    {
        yield return null;

        _startButtonObj = GameObject.Find("StartButton");
        Assert.IsNotNull(_startButtonObj);
        _startButton = _startButtonObj.GetComponent<StartButton>();
        Assert.IsNotNull(_startButton);
        //optionButton.OnClickButton();
        //Assert.IsTrue(settingModal.activeSelf);
        //Assert.IsFalse(menuButtons.activeSelf);
        //returnButton.OnClickButton();
        //Assert.IsTrue(menuButtons.activeSelf);
        //Assert.IsFalse(settingModal.activeSelf);
        //startButton.OnClickButton();
        //Assert.AreEqual(observerText.GetText(), "何の手を出すか決めてください");

    }

    // 送られてきたGameObjectのボタンコンポーネントに、
    // OnClickButtonがセットされているか確認する
    bool CheckOnclickButton(GameObject g)
    {
        var button = g.GetComponent<Button>();
        return (button.onClick.GetPersistentMethodName(0) == "OnClickButton");
    }
}
