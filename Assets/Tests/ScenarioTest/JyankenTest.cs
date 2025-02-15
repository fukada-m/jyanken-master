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
    GameManager gameManager;
    HandButtons handButtons;
    ObserverText observerText;

    GameObject textObject;
    GameObject gameManagerObj;
    ObserverText ot;
    Transform stoneButtonObj;
    Transform scissorsButtonObj;
    Transform paperButtonObj;
    Button stoneButtonComp;
    Button paperButtonComp;
    Button scissorsButtonComp;
    TMP_Text text;

    Sign.Hand Stone = Sign.Hand.Stone;
    Sign.Hand Paper = Sign.Hand.Paper;
    Sign.Hand Scissors = Sign.Hand.Scissors;

    [SetUp]
    public void JyankenTestSetUp()
    {
        gameManager = new GameObject().AddComponent<GameManager>();
        handButtons = new GameObject().AddComponent<HandButtons>();
        observerText = new GameObject().AddComponent<ObserverText>();
        //hand = new GameObject().AddComponent<Hand>();
        //hand.AddObserver(observerText);
    }

    //[UnitySetUp]
    //public IEnumerator Setup()
    //{
    //    SceneManager.LoadScene("JyankenScene");
    //    yield return null;

    //    //ゲームオブジェクトが揃っているか確認する
    //    GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
    //    handButtons = objects.FirstOrDefault(o => o.name == "HandButtons");
    //    Assert.IsNotNull(handButtons, "ハンドオブジェクトを作ろう");
    //    // HandButtonsは最初非表示になっている
    //    handButtons.SetActive(true);
    //    gameManagerObj = GameObject.Find("GameManager");
    //    Assert.IsNotNull(gameManagerObj, "GameManagerをオブジェクトを作成しよう");
    //    stoneButtonObj = handButtons.transform.Find("StoneButton");
    //    Assert.IsNotNull(stoneButtonObj, "Handの子オブジェクトにStoneButtonを作ろう");
    //    scissorsButtonObj = handButtons.transform.Find("ScissorsButton");
    //    Assert.IsNotNull(scissorsButtonObj, "Handの子オブジェクトにScissorsButtonを作ろう");
    //    paperButtonObj = handButtons.transform.Find("PaperButton");
    //    Assert.IsNotNull(paperButtonObj, "Handの子オブジェクトにPaperButtonを作ろう");
    //    observerText = GameObject.Find("ObserverText");
    //    Assert.IsNotNull(observerText, "ハンドオブザーバーがない。");
    //    textObject = GameObject.Find("Message");
    //    Assert.IsNotNull(textObject, "テキストオブジェクトがない");


    //    //コンポーネントが揃っているか確認する
    //    gameManager = gameManagerObj.GetComponent<GameManager>();
    //    Assert.IsNotNull(gameManager, "GameManagerコンポーネントをアタッチしよう");
    //    hand = handButtons.GetComponent<Hand>();
    //    Assert.IsNotNull(hand, "Handスクリプトを追加しよう");
    //    stoneButtonComp = stoneButtonObj.GetComponent<Button>();
    //    Assert.IsNotNull(stoneButtonComp, "StoneButonにButtonコンポーネントをつけよう");
    //    paperButtonComp = paperButtonObj.GetComponent<Button>();
    //    Assert.IsNotNull(paperButtonComp, "PaperButonにButtonコンポーネントをつけよう");
    //    scissorsButtonComp = scissorsButtonObj.GetComponent<Button>();
    //    Assert.IsNotNull(scissorsButtonComp, "ScissorsButonにButtonコンポーネントをつけよう");
    //    text = textObject.GetComponent<TMP_Text>();
    //    Assert.IsNotNull(text, "TMPコンポーネントがアタッチされてない");
    //    Assert.AreEqual("出す手を決めてください", text.text);
    //    ot = observerText.GetComponent<ObserverText>();
    //    Assert.IsNotNull(ot, "ハンドオブザーバースクリプトがない。");

    //    // ボタンにメソッドがアタッチしているか確認する
    //    Assert.IsTrue(stoneButtonComp.onClick.GetPersistentMethodName(0) == "onClickStoneButton",
    //        "StoneボタンにOnClickStoneButton()を設定しよう"
    //    );
    //    Assert.IsTrue(scissorsButtonComp.onClick.GetPersistentMethodName(0) == "onClickScissorsButton",
    //        "scissorsボタンにOnClickScissorsButton()を設定しよう"
    //    );
    //    Assert.IsTrue(paperButtonComp.onClick.GetPersistentMethodName(0) == "onClickPaperButton",
    //        "paperボタンにOnClickPaperButton()を設定しよう"
    //    );

    //}

    //// ボタンを押したらオブザーバーに通知が行くかテスト
    //[UnityTest]
    //public IEnumerator HandButtonsTest()
    //{
    //    // オブザーバーが追加できるかテスト
    //    var mock = new Mock<IObserver>();
    //    mock.Setup(service => service.Up(hand));
    //    hand.AddObserver(mock.Object);
    //    var observer = hand.GetObserver(0);
    //    Assert.IsInstanceOf<IObserver>(observer, "IObserver型ではなかった");

    //    //グーボタンをシミュレート
    //    stoneButtonComp.onClick.Invoke();
    //    Assert.AreEqual(hand.Current, Stone);
    //    //パーボタンをシミュレート
    //    paperButtonComp.onClick.Invoke();
    //    Assert.AreEqual(hand.Current, Paper);
    //    //チョキボタンをシミュレート
    //    scissorsButtonComp.onClick.Invoke();
    //    Assert.AreEqual(hand.Current, Scissors);

    //    // オブザーバーに通知が送れているかテスト。ボタンを3回押したから3回呼ばれている。
    //    mock.Verify(service => service.Up(hand), Times.Exactly(3));

    //    yield return null;
    //}

    //// ハンドの状態によってテキストを書き換えられるかテスト
    //[UnityTest]
    //public IEnumerator ObserverTest()
    //{
    //    // モックを作成
    //    var mock = new Mock<IHand>();

    //    //　初期表示
    //    Assert.AreEqual("出す手を決めてください", text.text);

    //    // グーを選んだ場合
    //    mock.Setup(p => p.Current).Returns(Stone);
    //    //　テキストの表示が変えられるかテスト
    //    ot.Up(mock.Object);
    //    Assert.AreEqual("グーを選んでいます", text.text);

    //    // パーを選んだ場合
    //    mock.Setup(p => p.Current).Returns(Paper);
    //    //　テキストの表示が変えられるかテスト
    //    ot.Up(mock.Object);
    //    Assert.AreEqual("パーを選んでいます", text.text);

    //    // チョキを選んだ場合
    //    mock.Setup(p => p.Current).Returns(Scissors);
    //    //　テキストの表示が変えられるかテスト
    //    ot.Up(mock.Object);
    //    Assert.AreEqual("チョキを選んでいます", text.text);

    //    yield return null;
    //}

    //// ハンドボタンの結合テスト
    //[UnityTest]
    //public IEnumerator JoinTest()
    //{

    //    //グーボタンをシミュレート
    //    stoneButtonComp.onClick.Invoke();
    //    Assert.AreEqual("グーを選んでいます", text.text);

    //    //パーボタンをシミュレート
    //    paperButtonComp.onClick.Invoke();
    //    Assert.AreEqual("パーを選んでいます", text.text);

    //    //チョキボタンをシミュレート
    //    scissorsButtonComp.onClick.Invoke();
    //    Assert.AreEqual("チョキを選んでいます", text.text);

    //    yield return null;
    //}
}
