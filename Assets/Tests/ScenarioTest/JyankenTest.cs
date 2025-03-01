using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;
using System.Collections.Generic;

public class JyankenTest
{
    GameObject handButtonsOBJ;
    GameObject ponButtonOBJ;
    GameObject resultButtonOBJ;
    Transform stoneButtonObj;
    Transform scissorsButtonObj;
    Transform paperButtonObj;
    Button stoneButton;
    Button paperButton;
    Button scissorsButton;
    Button ponButton;
    Button resultButton;
    TMP_Text text;

    [UnitySetUp]
    public IEnumerator Setup()
    {
        SceneManager.LoadScene("JyankenScene");
        yield return null;

        //最初非表示のHandButtonsを取得する
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        handButtonsOBJ = objects.FirstOrDefault(o => o.name == "HandButtons");
        ponButtonOBJ = objects.FirstOrDefault(o => o.name == "PonButton");
        resultButtonOBJ = objects.FirstOrDefault(o => o.name == "ResultButton");
        Assert.IsNotNull(handButtonsOBJ, "ハンドボタンオブジェクトを作ろう");
        Assert.IsNotNull(ponButtonOBJ, "ポンボタンオブジェクトを作ろう");
        Assert.IsNotNull(resultButtonOBJ, "リザルトボタンオブジェクトを作ろう");

        //HandButtonsの子オブジェクトを確認する
        stoneButtonObj = handButtonsOBJ.transform.Find("StoneButton");
        Assert.IsNotNull(stoneButtonObj, "HandButtonの子オブジェクトにStoneButtonを作ろう");
        scissorsButtonObj = handButtonsOBJ.transform.Find("ScissorsButton");
        Assert.IsNotNull(scissorsButtonObj, "HandButtonの子オブジェクトにScissorsButtonを作ろう");
        paperButtonObj = handButtonsOBJ.transform.Find("PaperButton");
        Assert.IsNotNull(paperButtonObj, "HandButtonの子オブジェクトにPaperButtonを作ろう");

        //Buttonが揃っているか確認する
        stoneButton = stoneButtonObj.GetComponent<Button>();
        Assert.IsNotNull(stoneButton, "StoneButonにButtonコンポーネントをつけよう");
        paperButton = paperButtonObj.GetComponent<Button>();
        Assert.IsNotNull(paperButton, "PaperButonにButtonコンポーネントをつけよう");
        scissorsButton = scissorsButtonObj.GetComponent<Button>();
        Assert.IsNotNull(scissorsButton, "ScissorsButonにButtonコンポーネントをつけよう");
        ponButton = ponButtonOBJ.GetComponent<Button>();
        Assert.IsNotNull(ponButton, "PonButonにButtonコンポーネントをアタッチしよう");
        resultButton = resultButtonOBJ.GetComponent<Button>();
        Assert.IsNotNull(resultButton, "ResultButtonにButtonコンポーネントをアタッチしよう");

        text = GameObject.Find("MessageText").GetComponent<TMP_Text>();
        Assert.IsNotNull(text, "TMPコンポーネントがアタッチされてない");
        // 最初にスタートボタンを押す
        var startButton = GameObject.Find("StartButton").GetComponent<Button>();
        startButton.onClick.Invoke();
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
        Assert.IsTrue(ponButton.onClick.GetPersistentMethodName(0) == "OnClickButton",
            "ポンボタンにOnClickButtonを設定しよう"
        );
        Assert.IsTrue(resultButton.onClick.GetPersistentMethodName(0) == "OnClickButton",
            "リザルトボタンにOnClickButtonを設定しよう"
        );
        resultButton = resultButtonOBJ.GetComponent<Button>();

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

    // じゃんけんをするテスト
    [UnityTest]
    public IEnumerator DoJyankenTest()
    {
        yield return null;
        // プレイヤーはグーを選択
        stoneButton.onClick.Invoke();
        // ポンボタンが押せるようになる
        Assert.IsTrue(ponButtonOBJ.activeSelf);
        // ポンボタンをクリック
        ponButton.onClick.Invoke();
        // HandButtonsは非表示になる。
        Assert.IsFalse(handButtonsOBJ.activeSelf);
        // リザルトボタンが押せるようになる
        Assert.IsTrue(resultButtonOBJ.activeSelf);
        // CPUが選んだ手を表示する
        var expectHand = new List<string> { "相手はグーを選びました", "相手はパーを選びました", "相手はチョキを選びました" };
        Assert.That(expectHand, Contains.Item(text.text));
        // リザルトボタンをクリック
        resultButton.onClick.Invoke();
        var expectResult = new List<string> { "結果は勝ちです", "結果はあいこです", "結果は負けです" };
        Assert.That(expectResult, Contains.Item(text.text));
    }
}
