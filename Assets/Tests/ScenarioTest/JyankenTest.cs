using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
using Moq;
using System.Linq;

public class JyankenTest
{
    GameObject handButtonsOBJ;
    HandButtons handButtons;
    Transform stoneButtonObj;
    Transform scissorsButtonObj;
    Transform paperButtonObj;
    Button stoneButton;
    Button paperButton;
    Button scissorsButton;
    Button ponButton;
    TMP_Text text;

    Sign.Hand Stone = Sign.Hand.Stone;
    Sign.Hand Paper = Sign.Hand.Paper;
    Sign.Hand Scissors = Sign.Hand.Scissors;

    [UnitySetUp]
    public IEnumerator Setup()
    {
        SceneManager.LoadScene("JyankenScene");
        yield return null;

        //最初非表示のHandButtonsを取得する
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        handButtonsOBJ = objects.FirstOrDefault(o => o.name == "HandButtons");
        var ponButtonOBJ = objects.FirstOrDefault(o => o.name == "PonButton");
        Assert.IsNotNull(handButtonsOBJ, "ハンドオブジェクトを作ろう");
        handButtons = handButtonsOBJ.GetComponent<HandButtons>();
        Assert.IsNotNull(handButtons, "HandButtonsをアタッチしよう");
        // HandButtonsは最初非表示になっているから表示する
        Assert.IsFalse(handButtonsOBJ.activeSelf);
        handButtonsOBJ.SetActive(true);

        //HandButtonsの子オブジェクトを確認する
        Assert.IsTrue(handButtonsOBJ.activeSelf);
        stoneButtonObj = handButtonsOBJ.transform.Find("StoneButton");
        Assert.IsNotNull(stoneButtonObj, "Handの子オブジェクトにStoneButtonを作ろう");
        scissorsButtonObj = handButtonsOBJ.transform.Find("ScissorsButton");
        Assert.IsNotNull(scissorsButtonObj, "Handの子オブジェクトにScissorsButtonを作ろう");
        paperButtonObj = handButtonsOBJ.transform.Find("PaperButton");
        Assert.IsNotNull(paperButtonObj, "Handの子オブジェクトにPaperButtonを作ろう");

        //Buttonが揃っているか確認する
        stoneButton = stoneButtonObj.GetComponent<Button>();
        Assert.IsNotNull(stoneButton, "StoneButonにButtonコンポーネントをつけよう");
        paperButton = paperButtonObj.GetComponent<Button>();
        Assert.IsNotNull(paperButton, "PaperButonにButtonコンポーネントをつけよう");
        scissorsButton = scissorsButtonObj.GetComponent<Button>();
        Assert.IsNotNull(scissorsButton, "ScissorsButonにButtonコンポーネントをつけよう");
        ponButton = ponButtonOBJ.GetComponent<Button>();
        Assert.IsNotNull(ponButton, "PonButonにButtonコンポーネントをアタッチしよう");

        text = GameObject.Find("MessageText").GetComponent<TMP_Text>();
        Assert.IsNotNull(text, "TMPコンポーネントがアタッチされてない");
        // 最初にスタートボタンを押す
        var startButton = GameObject.Find("StartButton").GetComponent<StartButton>();
        startButton.OnClickButton();
        Assert.AreEqual("何の手を出すか決めてください", text.text);

        // ボタンにメソッドがアタッチしているか確認する
        Assert.IsTrue(stoneButton.onClick.GetPersistentMethodName(0) == "OnClickStoneButton",
            "StoneボタンにOnClickStoneButton()を設定しよう"
        );
        Assert.IsTrue(scissorsButton.onClick.GetPersistentMethodName(0) == "OnClickScissorsButton",
            "scissorsボタンにOnClickScissorsButton()を設定しよう"
        );
        Assert.IsTrue(paperButton.onClick.GetPersistentMethodName(0) == "OnClickPaperButton",
            "paperボタンにOnClickPaperButton()を設定しよう"
        );

    }

    // ハンドボタンを複数回押したときのテスト
    [UnityTest]
    public IEnumerator HandButtonsClickTest()
    {

        //グーボタンをシミュレート
        stoneButton.onClick.Invoke();
        Assert.AreEqual("あなたはグーを選んでいます", text.text);

        //パーボタンをシミュレート
        paperButton.onClick.Invoke();
        Assert.AreEqual("あなたはパーを選んでいます", text.text);

        //チョキボタンをシミュレート
        scissorsButton.onClick.Invoke();
        Assert.AreEqual("あなたはチョキを選んでいます", text.text);

        //再度グーボタンをシミュレート
        stoneButton.onClick.Invoke();
        Assert.AreEqual("あなたはグーを選んでいます", text.text);

        yield return null;
    }

    [UnityTest]
    public IEnumerator DoJyankenTest()
    {
        yield return null;
        stoneButton.onClick.Invoke();
        ponButton.onClick.Invoke();
        // HandButtonsは非表示になる。
        Assert.IsFalse(handButtonsOBJ.activeSelf);
        // CPUが選んだ手を表示する

    }
}
