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
    GameObject handButtons;
    GameObject observerText;
    GameObject textObject;
    GameObject gameManagerObj;
    Hand hand;
    ObserverText ot;
    GameManager gameManager;
    Transform stoneButtonObj;
    Transform scissorsButtonObj;
    Transform paperButtonObj;
    Button stoneButtonComp;
    Button paperButtonComp;
    Button scissorsButtonComp;
    TMP_Text text;



    [UnitySetUp]
    public IEnumerator Setup()
    {
        SceneManager.LoadScene("JyankenScene");
        yield return null;

        //ゲームオブジェクトが揃っているか確認する
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        handButtons = objects.FirstOrDefault(o => o.name == "HandButtons");
        Assert.IsNotNull(handButtons, "ハンドオブジェクトを作ろう");
        // HandButtonsは最初非表示になっている
        handButtons.SetActive(true);
        hand = handButtons.GetComponent<Hand>();
        Assert.IsNotNull(hand, "Handスクリプトを追加しよう");
        gameManagerObj = GameObject.Find("GameManager");
        Assert.IsNotNull(gameManagerObj, "GameManagerをオブジェクトを作成しよう");
        stoneButtonObj = handButtons.transform.Find("StoneButton");
        Assert.IsNotNull(stoneButtonObj, "Handの子オブジェクトにStoneButtonを作ろう");
        scissorsButtonObj = handButtons.transform.Find("ScissorsButton");
        Assert.IsNotNull(scissorsButtonObj, "Handの子オブジェクトにScissorsButtonを作ろう");
        paperButtonObj = handButtons.transform.Find("PaperButton");
        Assert.IsNotNull(paperButtonObj, "Handの子オブジェクトにPaperButtonを作ろう");
        observerText = GameObject.Find("ObserverText");
        Assert.IsNotNull(observerText, "ハンドオブザーバーがない。");
        textObject = GameObject.Find("Message");
        Assert.IsNotNull(textObject, "テキストオブジェクトがない");

        //コンポーネントが揃っているか確認する
       gameManager = gameManagerObj.GetComponent<GameManager>();
        Assert.IsNotNull(gameManager, "GameManagerコンポーネントをアタッチしよう");
        stoneButtonComp = stoneButtonObj.GetComponent<Button>();
        Assert.IsNotNull(stoneButtonComp, "StoneButonにButtonコンポーネントをつけよう");
        paperButtonComp = paperButtonObj.GetComponent<Button>();
        Assert.IsNotNull(paperButtonComp, "PaperButonにButtonコンポーネントをつけよう");
        scissorsButtonComp = scissorsButtonObj.GetComponent<Button>();
        Assert.IsNotNull(scissorsButtonComp, "ScissorsButonにButtonコンポーネントをつけよう");
        text = textObject.GetComponent<TMP_Text>();
        Assert.IsNotNull(text, "TMPコンポーネントがアタッチされてない");
        Assert.AreEqual("出す手を決めてください", text.text);
        ot = observerText.GetComponent<ObserverText>();
        Assert.IsNotNull(ot, "ハンドオブザーバースクリプトがない。");

        // ボタンにメソッドがアタッチしているか確認する
        Assert.IsTrue(stoneButtonComp.onClick.GetPersistentMethodName(0) == "onClickStoneButton",
            "StoneボタンにOnClickStoneButton()を設定しよう"
        );
        Assert.IsTrue(scissorsButtonComp.onClick.GetPersistentMethodName(0) == "onClickScissorsButton",
            "scissorsボタンにOnClickScissorsButton()を設定しよう"
        );
        Assert.IsTrue(paperButtonComp.onClick.GetPersistentMethodName(0) == "onClickPaperButton",
            "paperボタンにOnClickPaperButton()を設定しよう"
        );

    }

    // ボタンを押したらオブザーバーに通知が行くかテスト
    [UnityTest]
    public IEnumerator HandButtonsTest()
    {
        // オブザーバーが追加できるかテスト
        var mock = new Mock<IObserver>();
        mock.Setup(service => service.Up(hand));
        hand.AddObserver(mock.Object);
        var observer = hand.GetObserver(0);
        Assert.IsInstanceOf<IObserver>(observer, "IObserver型ではなかった");

        //グーボタンをシミュレート
        stoneButtonComp.onClick.Invoke();
        Assert.AreEqual(hand.Current, "stone");
        //パーボタンをシミュレート
        paperButtonComp.onClick.Invoke();
        Assert.AreEqual(hand.Current, "paper");
        //チョキボタンをシミュレート
        scissorsButtonComp.onClick.Invoke();
        Assert.AreEqual(hand.Current, "scissors");

        // オブザーバーに通知が送れているかテスト。ボタンを3回押したから3回呼ばれている。
        mock.Verify(service => service.Up(hand), Times.Exactly(3));

        yield return null;
    }

    // ハンドの状態によってテキストを書き換えられるかテスト
    [UnityTest]
    public IEnumerator ObserverTest()
    {
        // モックを作成
        var mock = new Mock<IHand>();

        // グーを選んだ場合
        mock.Setup(p => p.Current).Returns("stone");
        //　テキストの表示が変えられるかテスト
        ot.Up(mock.Object);
        Assert.AreEqual("chose stone", text.text);

        // パーを選んだ場合
        mock.Setup(p => p.Current).Returns("paper");
        //　テキストの表示が変えられるかテスト
        ot.Up(mock.Object);
        Assert.AreEqual("chose paper", text.text);

        // チョキを選んだ場合
        mock.Setup(p => p.Current).Returns("scissors");
        //　テキストの表示が変えられるかテスト
        ot.Up(mock.Object);
        Assert.AreEqual("chose scissors", text.text);

        yield return null;
    }

    // ハンドボタンの結合テスト
    [UnityTest]
    public IEnumerator JoinTest()
    {

        //グーボタンをシミュレート
        stoneButtonComp.onClick.Invoke();
        Assert.AreEqual("chose stone", text.text);

        //パーボタンをシミュレート
        paperButtonComp.onClick.Invoke();
        Assert.AreEqual("chose paper", text.text);

        //チョキボタンをシミュレート
        scissorsButtonComp.onClick.Invoke();
        Assert.AreEqual("chose scissors", text.text);

        yield return null;
    }
}
